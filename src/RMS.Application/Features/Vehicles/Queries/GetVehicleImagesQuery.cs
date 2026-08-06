using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Queries
{
    public record GetVehicleImagesQuery :IRequest<Response<List<VehicleImage>>>
    {
        public Guid VehicleId { get; init; }
    }
}