using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;
using RMS.Application.Features.Vehicles.Commands.GetVehicle;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Commands.UpdateVehicle
{
  public class UpdateVehicleHandler : IRequestHandler<UpdateVehicle, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public UpdateVehicleHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Response<string>> Handle(UpdateVehicle request, CancellationToken cancellationToken)
    {
       var existingVehicle = await _context.Vehicles
       .Include(x=>x.Category)
       .FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);

        if (existingVehicle == null)
            {
                return Response<string>.Failure(
                    $"Vehicle with ID '{request.Id}' was not found",
                    "VEHICLE_NOT_FOUND" // Optional error code
                );
            }  
            
         // Update the entity with values from the request
            existingVehicle.Brand = request.Brand;
            existingVehicle.Model = request.Model;
            existingVehicle.Year = request.Year;
            existingVehicle.PlateNumber = request.PlateNumber;
            existingVehicle.DailyRate = request.DailyRate;
            existingVehicle.Status = request.Status;
            existingVehicle.CategoryId = request.CategoryId; // Assuming you have CategoryId

            _context.Vehicles.Update(existingVehicle);
            await _context.SaveChangesAsync(cancellationToken);

            // var updatedVehicleDto = new UpdateVehicleDto
            //   {
            //     Brand = existingVehicle.Brand,
            //     Model = existingVehicle.Model,
            //     Year = existingVehicle.Year,
            //     PlateNumber = existingVehicle.PlateNumber,
            //     DailyRate = existingVehicle.DailyRate,
            //     Status = existingVehicle.Status,
            //     CategoryName = existingVehicle.Category.Name  
            //   }; 

              return Response<string>.Success("", "Vehicle updated successfully");
    }
  }
}