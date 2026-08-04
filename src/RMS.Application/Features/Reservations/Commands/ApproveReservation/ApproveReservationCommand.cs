using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reservations.Commands.ApproveReservation
{
    public class ApproveReservationCommand :IRequest<Response<string>>
    {
        public Guid Id { get; set; }
    }
}