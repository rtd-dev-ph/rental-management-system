using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Features.Reservations.Commands.CreateReservation;
using RMS.Application.Features.Vehicles.Commands.GetVehicle;
using RMS.Infrastructure.Persistence.Context;
using Xunit;

namespace RMS.UnitTests.Features.Reservations
{ 
    public class AvailabilityTests
    {

 private readonly ApplicationDbContext _context;
    private readonly GetVehicleByIdHandler _handler;

    //     [Fact]
    //     public void NoOverlap_WhenNewEndIsBeforeExistingStart_ShouldBeAvailable()
    //     {
    //         // Assert.True(true);

    //         //Exisiting Aug 5-10
    //         //New: Aug 1-4

    //         var existingStart = new DateTime(2026,8,5);
    //         var existingEnd = new DateTime(2026,8,10);
    //         var newStart = new DateTime(2026,8,1);
    //         var newEnd = new DateTime(2026,8,4);

    //         var hasOverlap = existingStart < newEnd && existingEnd > newStart;

    //         hasOverlap.Should().BeFalse();
    //     }

    //      [Fact]
    //     public void Overlap_WhenNewBookingContainsExisting_ShouldReturnTrue()
    //     {
    //         // Existing: Aug 5-10, New: Aug 1-15
    //         var hasOverlap = new DateTime(2026, 8, 5) < new DateTime(2026, 8, 15)
    //                     && new DateTime(2026, 8, 10) > new DateTime(2026, 8, 1);
            
    //         hasOverlap.Should().BeTrue();
    //     }
        
    //     [Fact]
    //     public void NoOverlap_WhenSameDayCheckout_ShouldReturnFalse()
    //     {
    //     // Existing: Aug 5-10, New: Aug 10-15 (checkout day = new start day)
    //     var hasOverlap = new DateTime(2026, 8, 5) < new DateTime(2026, 8, 15)
    //                   && new DateTime(2026, 8, 10) > new DateTime(2026, 8, 10);
        
    //     hasOverlap.Should().BeFalse();
    // }
 
    public AvailabilityTests()
    {
         var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        _context = new ApplicationDbContext(options);
        _handler = new GetVehicleByIdHandler(_context);
    
    }

 // 1. Write a test first
[Fact]
public async Task ShouldFail_WhenVehicleNotFound()
{
    // Arrange
    var vehicleId = Guid.NewGuid(); // Doesn't exist

    // var command = new CreateReservationCommand
    // {
    //   Id = new Guid(),
    //     VehicleId = vehicleId,
    //     CustomerId = new Guid(),
    //     StartDate = DateTime.UtcNow,
    //     EndDate = DateTime.UtcNow.AddDays(3),
    //     Status = "Pending",
    //     TotalAmount = 500,
    //     CreatedAt = DateTime.UtcNow
    // };

    var id = new GetVehicleById
    {
        
      Id  = Guid.Parse("019fb339-6a36-7979-95b0-131baed08873")
    };
 
    
    // Act
    var result = await _handler.Handle(id,CancellationToken.None);
    
    // Assert
    result.IsSuccess.Should().BeFalse();
    result.Message.Should().Be($"Vehicle with ID '{id.Id}' was not found");
}

// 2. Now go implement the code to make it pass!
   
}
}