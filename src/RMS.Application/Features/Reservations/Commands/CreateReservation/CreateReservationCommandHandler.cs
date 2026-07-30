using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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
     var reservation = new Reservation()
       {
           Id = new Guid(),
           VehicleId = request.VehicleId,
           Vehicle = request.Vehicle,
           CustomerId = request.CustomerId,
           Customer = request.Customer,
           StartDate = request.StartDate,
           EndDate = request.EndDate,
           Status = "Pending",
           TotalAmount = request.TotalAmount,
           Notes = request.Notes,
           CreatedAt = DateTime.UtcNow
       };

       await _context.Reservations.AddAsync(reservation);
       await _context.SaveChangesAsync(cancellationToken);

       return Response<string>.Success("Reservation currently pending.");
  }
}

