using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace RMS.Application.Features.Vehicles.Commands.UploadImage
{
    public class UploadImageCommand : IRequest<Response<Guid>>
    {
        public Guid VehicleId { get; set; }
        public IFormFile File { get; set; } = null!;
        public bool IsCover { get; set; }
    }
}