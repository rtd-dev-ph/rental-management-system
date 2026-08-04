using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Rentals.Commands.PickupVehicle
{
    public class PickupVehicleCommand :IRequest<Response<string>>
    {
        public Guid ReservationId { get; set; }
        public string? Notes { get; set; }
    }
}