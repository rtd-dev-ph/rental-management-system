using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicle : IRequest<Response<string>>
    {
        public Guid Id { get; init; }
        public string Brand { get; init; } = string.Empty;
        public string Model { get; init; } = string.Empty;
        public int Year { get; init; }
        public string PlateNumber { get; init; } = string.Empty;
        public decimal DailyRate { get; init; }
        public string Status { get; init; } = string.Empty;
        public int CategoryId { get; init; }
    }
}