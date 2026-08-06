using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Vehicles.Commands.DeleteImage
{
    public class DeleteImagesCommand : IRequest<Response<string>>
    {
        public Guid ImageId { get; init; }
    }
}