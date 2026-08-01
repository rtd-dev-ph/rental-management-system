 
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Features.Reservations.Commands.CreateReservation;
using RMS.Domain.Entities;
using RMS.Infrastructure.Persistence.Context;

namespace RMS.UnitTests.Features.Reservations;

public class CreateReservationTests
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

    // [Fact]
    // public async Task ShouldFail_WhenVehicleNotFound()
    // {
    //     var command = new CreateReservationCommand
    //     {
    //         VehicleId = Guid.NewGuid(),
    //         CustomerId = Guid.NewGuid(),
    //         StartDate = DateTime.UtcNow.AddDays(1),
    //         EndDate = DateTime.UtcNow.AddDays(3),
    //         TotalAmount = 5000
    //     };

    //     var result = await _handler.Handle(command, CancellationToken.None);

    //     result.IsSuccess.Should().BeFalse();
    //     result.Message.Should().Be("Vehicle not found");
    // }

    // [Fact]
    // public async Task ShouldCreateReservation_WhenValid()
    // {
    //     // Arrange - add a vehicle first
    //     var vehicle = new Vehicle
    //     {
    //         Id = Guid.NewGuid(),
    //         Brand = "Honda",
    //         Model = "Civic",
    //         Year = 2024,
    //         PlateNumber = "ABC-1234",
    //         DailyRate = 2500,
    //         Status = "Available",
    //         CategoryId = 1,
    //         CreatedAt = DateTime.UtcNow
    //     };
    //     _context.Vehicles.Add(vehicle);
    //     await _context.SaveChangesAsync();

    //     var command = new CreateReservationCommand
    //     {
    //         VehicleId = vehicle.Id,
    //         CustomerId = Guid.NewGuid(),
    //         StartDate = DateTime.UtcNow.AddDays(1),
    //         EndDate = DateTime.UtcNow.AddDays(3),
    //         TotalAmount = 5000
    //     };

    //     // Act
    //     var result = await _handler.Handle(command, CancellationToken.None);

    //     // Assert
    //     result.IsSuccess.Should().BeTrue();
    // }

    // [Fact]
    // public async Task ShouldFail_WhenVehicleNotAvailable()
    // {
    //     var vehicle = new Vehicle
    //     {
    //         Id = Guid.NewGuid(),
    //         Brand = "Honda",
    //         Model = "Civic",
    //         Year = 2024,
    //         PlateNumber = "DEF-5678",
    //         DailyRate = 2500,
    //         Status = "Maintenance",  // Not available!
    //         CategoryId = 1,
    //         CreatedAt = DateTime.UtcNow
    //     };
    //     _context.Vehicles.Add(vehicle);
    //     await _context.SaveChangesAsync();

    //     var command = new CreateReservationCommand
    //     {
    //         VehicleId = vehicle.Id,
    //         CustomerId = Guid.NewGuid(),
    //         StartDate = DateTime.UtcNow.AddDays(1),
    //         EndDate = DateTime.UtcNow.AddDays(3),
    //         TotalAmount = 5000
    //     };

    //     var result = await _handler.Handle(command, CancellationToken.None);

    //     result.IsSuccess.Should().BeFalse();
    //     result.Message.Should().Contain("Maintenance");
    // }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
 