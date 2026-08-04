using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand :IRequest<Response<string>>
    {
        public Guid Id { get; init; }
        public Guid VehicleId { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public decimal TotalAmount { get; init; }
        public string? Notes { get; init; }
    }
}