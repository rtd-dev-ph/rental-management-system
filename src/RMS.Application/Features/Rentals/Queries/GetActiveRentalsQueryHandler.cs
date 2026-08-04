using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Rentals.Queries
{
  public class GetActiveRentalsQueryHandler : IRequestHandler<GetActiveRentalsQuery, Response<List<RentalTransaction>>>
  {
    private readonly IApplicationDbContext _context;

    public GetActiveRentalsQueryHandler(IApplicationDbContext context)
    {
     _context = context;
    }
    public async Task<Response<List<RentalTransaction>>> Handle(GetActiveRentalsQuery request, CancellationToken cancellationToken)
    {
      var rentals = await _context.RentalTransactions
            .Include(r => r.Vehicle)
            .Include(r => r.Reservation)
            .Where(r => r.Status == "Active")
            .ToListAsync(cancellationToken);

            if(rentals == null || rentals.Count <= 0)
             return Response<List<RentalTransaction>>.Failure("Records not found.");

            return Response<List<RentalTransaction>>.Success(rentals);
    }
  }
}