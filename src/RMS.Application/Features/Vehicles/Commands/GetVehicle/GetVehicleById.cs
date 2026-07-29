using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Vehicles.Commands.GetVehicle
{
    public class GetVehicleById : IRequest<Response<VehicleDto>>
    {
        public Guid Id { get; init; }
    }
}