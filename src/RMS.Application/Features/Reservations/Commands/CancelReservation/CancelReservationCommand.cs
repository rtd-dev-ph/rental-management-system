using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reservations.Commands.CancelReservation
{
    public class CancelReservationCommand : IRequest<Response<string>>
    {
        public Guid Id { get; init; }
    }
}