using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Rentals.Commands.ReturnVehicle
{
  public class ReturnVehicleCommandHandler : IRequestHandler<ReturnVehicleCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public ReturnVehicleCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Response<string>> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
    {
       var rentalTransaction = await _context.RentalTransactions 
       .FirstOrDefaultAsync(x=>x.Id == request.RentalId,cancellationToken); 

       if(rentalTransaction == null)
        return Response<string>.Failure($"Rental ID not found.");

       var reservation = await _context.Reservations
       .FirstOrDefaultAsync(x=>x.Id.Equals(rentalTransaction.ReservationId),cancellationToken);

       var vehicle = await _context.Vehicles
       .FirstOrDefaultAsync(x=>x.Id.Equals(rentalTransaction.VehicleId),cancellationToken);

        if(vehicle == null)
                return Response<string>.Failure($"Vehicle ID not found.");

        if(reservation == null)
        return Response<string>.Failure("Reservation not found.");

        string[] status = {"Approved", "Rented"};

        if(!status.Contains(reservation.Status))
                return Response<string>.Failure("Reservation must be approved first");
        
        rentalTransaction.ReturnDate = DateTime.UtcNow;
        rentalTransaction.Status = "Completed";
        vehicle.Status = "Available";
        reservation.Status = "Completed";

        await _context.SaveChangesAsync(cancellationToken);
        return Response<string>.Success("Vehicle returned."); 
    }
  }
}