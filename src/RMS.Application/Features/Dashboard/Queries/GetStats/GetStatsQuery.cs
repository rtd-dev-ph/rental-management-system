using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Dashboard.Queries.GetStats
{
    public class DashboardStatsDto
    {
        public int TotalVehicles { get; init; }
        public int AvailableVehicles { get; init; }
        public int RentedVehicles { get; init; }
        public int MaintenanceVehicles { get; init; }
        public int ActiveRentals { get; init; }
        public int TodayReservations { get; init; }
        public decimal TodayRevenue { get; init; }
    }
    
    public record GetStatsQuery : IRequest<Response<DashboardStatsDto>>;
}