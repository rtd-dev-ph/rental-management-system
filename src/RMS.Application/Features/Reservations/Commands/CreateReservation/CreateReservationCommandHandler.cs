using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Reservations.Commands.CreateReservation;

  public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public CreateReservationCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

  public async Task<Response<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
  {
    // Check availability - prevent double booking

    var  isBooked = await _context.Reservations
    .AnyAsync(r=>r.VehicleId == request.VehicleId
    && r.Status != "Cancelled" 
    && r.StartDate < request.EndDate 
    && r.EndDate > request.StartDate, cancellationToken);

    if(isBooked)
      return Response<string>.Failure("Vehicle is not available for these dates");

     var reservation = new Reservation()
       {
           Id = new Guid(),
           VehicleId = request.VehicleId,  
           CustomerId = request.CustomerId, 
           StartDate = request.StartDate,
           EndDate = request.EndDate,
           Status = "Cancelled",
           TotalAmount = request.TotalAmount,
           Notes = request.Notes,
           CreatedAt = DateTime.UtcNow
       };

       await _context.Reservations.AddAsync(reservation);
       await _context.SaveChangesAsync(cancellationToken);

       return Response<string>.Success("Reservation currently pending.");
  }
}

