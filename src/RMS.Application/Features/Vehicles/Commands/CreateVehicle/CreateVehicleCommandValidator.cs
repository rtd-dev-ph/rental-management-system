using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using RMS.Application.Common.Interfaces;

namespace RMS.Application.Features.Vehicles.Commands.CreateVehicle
{
  public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
  {
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Brand).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Model).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Year).InclusiveBetween(2000, 2030);
        RuleFor(x => x.PlateNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.DailyRate).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
  }
}