using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using RMS.Application.Common.Interfaces;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Commands.CreateVehicle
{
  public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
  {
    private readonly IApplicationDbContext _context;

    public CreateVehicleCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle  = new Vehicle()
        {
          Id = new Guid(),
          Brand = request.Brand,
          Model = request.Model,
          Year = request.Year,
          PlateNumber = request.PlateNumber,
          DailyRate = request.DailyRate,
          CategoryId = request.CategoryId,
          Status = "Available",
          CreatedAt = DateTime.UtcNow
        };

        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync(cancellationToken);
        return vehicle.Id;
    }
  }
}