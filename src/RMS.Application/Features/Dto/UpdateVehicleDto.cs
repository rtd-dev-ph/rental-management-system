using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Application.Features.Dto
{
    public class UpdateVehicleDto
    { 
        // public Guid Id { get; init; }    
        public string Brand { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public int Year { get; init; }
        public string PlateNumber { get; init; } = string.Empty;
        public decimal DailyRate { get; init; }
        public string Status { get; init; } = string.Empty;
        public string CategoryName { get; init; } = string.Empty;
    }
}