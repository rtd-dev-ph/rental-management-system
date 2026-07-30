using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Commands.GetVehicle
{
    public record GetVehicleCommand : IRequest<List<VehicleDto>>;
}