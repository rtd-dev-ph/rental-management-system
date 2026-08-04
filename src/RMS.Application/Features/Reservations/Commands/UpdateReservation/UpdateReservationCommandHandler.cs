using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reservations.Commands.UpdateReservation
{
  public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public UpdateReservationCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Response<string>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    { 
        var reservation = await _context.Reservations
                         .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (reservation == null)
            return Response<string>.Failure("Reservation not found");

        // 2. Find the vehicle
        var vehicle = await _context.Vehicles
                     .FirstOrDefaultAsync(v => v.Id == request.VehicleId, cancellationToken);

        if (vehicle == null)
            return Response<string>.Failure("Vehicle not found");

        // 3. Check vehicle status (skip if same vehicle)
        if (reservation.VehicleId != request.VehicleId)
        {
            if (vehicle.Status == "Rented" || vehicle.Status == "Maintenance")
                return Response<string>.Failure($"Vehicle is currently {vehicle.Status}");
        }
    // Check availability - prevent double booking

    var  isBooked = await _context.Reservations
    .AnyAsync(r=>r.VehicleId == request.VehicleId
    && r.Status != "Cancelled" 
    && r.StartDate < request.EndDate 
    && r.EndDate > request.StartDate, cancellationToken);

    if(isBooked)
      return Response<string>.Failure("Vehicle is not available for these dates");
  
      reservation.VehicleId = request.VehicleId;
      reservation.StartDate = request.StartDate;
      reservation.EndDate = request.EndDate;
      reservation.TotalAmount = request.TotalAmount;
      reservation.Notes = request.Notes;
      reservation.UpdatedAt = DateTime.UtcNow;
       
       await _context.SaveChangesAsync(cancellationToken);

       return Response<string>.Success("Reservation updated successfully.");
    } 
  }
}