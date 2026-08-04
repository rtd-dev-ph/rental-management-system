using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reports.Queries.GetRevenue
{
    public record RevenueDto
    {
        public decimal TotalRevenue { get; init; }
        public int TotalRentals { get; init; }
        public DateTime FromDate { get; init; }
        public DateTime ToDate { get; init; }
    }

    public record GetRevenueQuery : IRequest<Response<RevenueDto>>
    {
        public DateTime FromDate { get; init; }
        public DateTime ToDate { get; init; }
    }
}