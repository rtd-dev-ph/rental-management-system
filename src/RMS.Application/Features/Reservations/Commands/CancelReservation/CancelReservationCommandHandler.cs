using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reservations.Commands.CancelReservation
{
  public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public CancelReservationCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    } 

    public async  Task<Response<string>> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
       var reservation = await _context.Reservations
       .FirstOrDefaultAsync(x=>x.Id == request.Id,cancellationToken);

       if(reservation == null)
        return Response<string>.Failure("Reservation not found.");

        reservation.Status = "Cancelled";
        reservation.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Response<string>.Success("Reservation cancelled successfully.");


    }
  }
}