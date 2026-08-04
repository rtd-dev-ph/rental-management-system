using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Rentals.Commands.PickupVehicle.Queries
{
  public class GetAllRentalTransactionsQueryHandler : IRequestHandler<GetAllRentalTransactionsQuery, Response<List<GetRentalTransactionsDto>>>
  {
    private readonly IApplicationDbContext _context;
    public GetAllRentalTransactionsQueryHandler(IApplicationDbContext context)
    {
      _context = context;
        
    }
    public async Task<Response<List<GetRentalTransactionsDto>>> Handle(GetAllRentalTransactionsQuery request, CancellationToken cancellationToken)
    {
      var rentalTransactions = await _context.RentalTransactions
      .Include(t=>t.Vehicle)
      .Include(t=>t.Reservation) 
      .Select(x=> new GetRentalTransactionsDto
      {
          RentalId = x.Id,
          ReservationId = x.ReservationId,
          VehicleId = x.VehicleId,
          PickupDate = x.PickupDate,
          ReturnDate = x.ReturnDate,
          RentalStatus = x.Status,
          RentalNotes = x.Notes,
          ReservationStatus = x.Reservation.Status,
          ReservationNotes = x.Reservation.Notes,
          Brand = x.Vehicle.Brand,
          Model = x.Vehicle.Model,
          Year = x.Vehicle.Year,
          PlateNumber= x.Vehicle.PlateNumber 
      })
      .ToListAsync(cancellationToken);

      if(rentalTransactions == null || rentalTransactions.Count < 0)
         return Response<List<GetRentalTransactionsDto>>.Failure("No records found.");
 
       return Response<List<GetRentalTransactionsDto>>.Success(rentalTransactions);
    }
  }
}