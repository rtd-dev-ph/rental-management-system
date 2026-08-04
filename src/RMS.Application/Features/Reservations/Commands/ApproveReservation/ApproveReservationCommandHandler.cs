using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reservations.Commands.ApproveReservation
{
  public class ApproveReservationCommandHandler : IRequestHandler<ApproveReservationCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public ApproveReservationCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Response<string>> Handle(ApproveReservationCommand request, CancellationToken cancellationToken)
    {
       var reservation = await _context.Reservations 
       .FirstOrDefaultAsync(x=>x.Id == request.Id,cancellationToken);

       if(reservation == null)
        return Response<string>.Failure("Reservation not found.");

    if(reservation.Status != "Pending")
        return Response<string>.Failure($"Cannot approve reservation with status: {reservation.Status}");

        reservation.Status = "Approved";
        reservation.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Response<string>.Success("Reservation approved"); 
    }
  }
}