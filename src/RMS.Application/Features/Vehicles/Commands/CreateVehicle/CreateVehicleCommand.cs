using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RMS.Application.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand :IRequest<Guid>
    {
        public string Brand { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public int Year { get; init; }
        public string PlateNumber { get; init; } = string.Empty;
        public decimal DailyRate { get; init; }
        public int CategoryId { get; init; }
    }
}