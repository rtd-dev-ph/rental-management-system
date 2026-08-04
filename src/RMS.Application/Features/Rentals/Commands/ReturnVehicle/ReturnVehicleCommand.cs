using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Rentals.Commands.ReturnVehicle
{
    public class ReturnVehicleCommand :IRequest<Response<string>>
    {
        public Guid RentalId { get; init; }
        public string? Notes { get; init; }
    }
}