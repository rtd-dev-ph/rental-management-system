using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;

namespace RMS.Application.Features.Reservations.Commands.CreateReservation;

    public class CreateReservationCommandValidator: AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(x => x.VehicleId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.StartDate).GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.EndDate).GreaterThan(x=>x.StartDate);
        }
    }
