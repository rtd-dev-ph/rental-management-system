using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reports.Queries.GetRevenue;

public class GetRevenueQueryHandler : IRequestHandler<GetRevenueQuery, Response<RevenueDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRevenueQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Response<RevenueDto>> Handle(GetRevenueQuery request, CancellationToken cancellationToken)
    {
        var rentals = await _context.RentalTransactions
            .Where(r => r.PickupDate >= request.FromDate && r.PickupDate <= request.ToDate)
            .ToListAsync(cancellationToken);

        var revenue = new RevenueDto
        {
            TotalRevenue = rentals.Sum(r => r.TotalAmount),
            TotalRentals = rentals.Count,
            FromDate = request.FromDate,
            ToDate = request.ToDate
        };

        return Response<RevenueDto>.Success(revenue);
    }
}