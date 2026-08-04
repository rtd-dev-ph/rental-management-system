using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Dashboard.Queries.GetStats
{
  public class GetStatsQueryHandler : IRequestHandler<GetStatsQuery, Response<DashboardStatsDto>>
  {
    private readonly IApplicationDbContext _context;
    public GetStatsQueryHandler(IApplicationDbContext context)
    {
      _context = context;
        
    }

    public async Task<Response<DashboardStatsDto>> Handle(GetStatsQuery request, CancellationToken cancellationToken)
    {
       var today = DateTime.UtcNow.Date;

        var stats = new DashboardStatsDto
        {
            TotalVehicles = await _context.Vehicles.CountAsync(cancellationToken),
            AvailableVehicles = await _context.Vehicles.CountAsync(v => v.Status == "Available", cancellationToken),
            RentedVehicles = await _context.Vehicles.CountAsync(v => v.Status == "Rented", cancellationToken),
            MaintenanceVehicles = await _context.Vehicles.CountAsync(v => v.Status == "Maintenance", cancellationToken),
            ActiveRentals = await _context.RentalTransactions.CountAsync(r => r.Status == "Active", cancellationToken),
            TodayReservations = await _context.Reservations.CountAsync(r => r.StartDate.Date == today, cancellationToken),
            TodayRevenue = await _context.RentalTransactions
                .Where(r => r.PickupDate.Date == today)
                .SumAsync(r => r.TotalAmount, cancellationToken)
        };

        return Response<DashboardStatsDto>.Success(stats);
    }
  }
}