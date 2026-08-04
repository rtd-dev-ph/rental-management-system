using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Rentals.Commands.PickupVehicle
{
  public class PickupVehicleCommandHandler : IRequestHandler<PickupVehicleCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;
    public PickupVehicleCommandHandler(IApplicationDbContext context)
    {
      _context = context; 
    }
    public async Task<Response<string>> Handle(PickupVehicleCommand request, CancellationToken cancellationToken)
    {
       var data = await _context.Reservations
       .FirstOrDefaultAsync(x=>x.Id.Equals(request.ReservationId),cancellationToken);

       if(data == null)
        return Response<string>.Failure("Reservation not exist.");

       string[] status = {"Approved", "Pending"};

       if(!status.Contains(data?.Status))
        return Response<string>.Failure("Reservation not exist.");

        var vehicle = await _context.Vehicles
        .FirstOrDefaultAsync(x=>x.Id.Equals(data!.VehicleId));

        if(!vehicle!.Status.Equals("Available"))
            return Response<string>.Failure("Vehicle not available.");
        
        var pickUpVehicle = new RentalTransaction
        {
          Id = new Guid(),
          ReservationId = data!.Id,
          VehicleId = data!.VehicleId,
          PickupDate = DateTime.UtcNow,
          ReturnDate = null,
          TotalAmount = data.TotalAmount,
          Status = "Active",
          Notes = request.Notes,
          CreatedAt = DateTime.UtcNow 
        };

        await _context.RentalTransactions.AddAsync(pickUpVehicle);
        
        data.Status = "Rented";
        vehicle.Status = "Rented"; 

        await _context.SaveChangesAsync(cancellationToken); 

        return Response<string>.Failure("Data saved."); 
    }
  }
}