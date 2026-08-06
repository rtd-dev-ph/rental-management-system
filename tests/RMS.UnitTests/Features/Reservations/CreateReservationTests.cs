// tests/RMS.UnitTests/Features/Reservations/CreateReservationTests.cs
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Models;
using RMS.Application.Features.Reservations.Commands.CreateReservation;
using RMS.Domain.Entities;
using RMS.Infrastructure.Persistence.Context;

namespace RMS.UnitTests.Features.Reservations;

public class CreateReservationTests : IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly CreateReservationCommandHandler _handler;

    public CreateReservationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new ApplicationDbContext(options);
        _handler = new CreateReservationCommandHandler(_context);
    }

    [Fact]
    public async Task ShouldFail_WhenVehicleNotFound()
    {
        var command = new CreateReservationCommand
        {
            VehicleId = Guid.NewGuid(),
            CustomerId = Guid.NewGuid(),
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(3),
            TotalAmount = 5000
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be("Vehicle not found.");
    }

    [Fact]
    public async Task ShouldFail_WhenVehicleInMaintenance()
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Brand = "Honda",
            Model = "Civic",
            Year = 2024,
            PlateNumber = "TEST-001",
            DailyRate = 2500,
            Status = "Maintenance",
            CategoryId = 1,
            CreatedAt = DateTime.UtcNow
        };
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        var command = new CreateReservationCommand
        {
            VehicleId = vehicle.Id,
            CustomerId = Guid.NewGuid(),
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(3),
            TotalAmount = 5000
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Contain("Maintenance");
    }

    [Fact]
    public async Task ShouldCreateReservation_WhenValid()
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Brand = "Honda",
            Model = "Civic",
            Year = 2024,
            PlateNumber = "TEST-002",
            DailyRate = 2500,
            Status = "Available",
            CategoryId = 1,
            CreatedAt = DateTime.UtcNow
        };
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        var command = new CreateReservationCommand
        {
            VehicleId = vehicle.Id,
            CustomerId = Guid.NewGuid(),
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(3),
            TotalAmount = 5000
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task ShouldFail_WhenDatesOverlap()
    {
        // Arrange
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Brand = "Toyota",
            Model = "Vios",
            Year = 2024,
            PlateNumber = "TEST-003",
            DailyRate = 2000,
            Status = "Available",
            CategoryId = 1,
            CreatedAt = DateTime.UtcNow
        };
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        // Existing reservation: Aug 5-10
        var existing = new Reservation
        {
            Id = Guid.NewGuid(),
            VehicleId = vehicle.Id,
            CustomerId = Guid.NewGuid(),
            StartDate = new DateTime(2026, 8, 5, 0, 0, 0, DateTimeKind.Utc),
            EndDate = new DateTime(2026, 8, 10, 0, 0, 0, DateTimeKind.Utc),
            Status = "Approved",
            TotalAmount = 5000,
            CreatedAt = DateTime.UtcNow
        };
        _context.Reservations.Add(existing);
        await _context.SaveChangesAsync();

        // New reservation: Aug 7-12 (overlaps!)
        var command = new CreateReservationCommand
        {
            VehicleId = vehicle.Id,
            CustomerId = Guid.NewGuid(),
            StartDate = new DateTime(2026, 8, 7, 0, 0, 0, DateTimeKind.Utc),
            EndDate = new DateTime(2026, 8, 12, 0, 0, 0, DateTimeKind.Utc),
            TotalAmount = 5000
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Contain("not available");
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}