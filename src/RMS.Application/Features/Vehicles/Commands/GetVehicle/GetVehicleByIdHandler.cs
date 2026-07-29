using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Vehicles.Commands.GetVehicle
{
  public class GetVehicleByIdHandler : IRequestHandler<GetVehicleById, Response<VehicleDto>>
  {
    private readonly IApplicationDbContext _context;

    public GetVehicleByIdHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Response<VehicleDto>>Handle(GetVehicleById request, CancellationToken cancellationToken)
    {
      var data = await _context.Vehicles
      .Include(x=>x.Category)
      .Where(x=>x.Id == request.Id)
      .Select(x=> new VehicleDto
      {
          Id = x.Id,
          Brand = x.Brand,
          Model = x.Model,
          Year = x.Year,
          PlateNumber = x.PlateNumber,
          DailyRate = x.DailyRate,
          Status = x.Status,
          CategoryName = x.Category.Name 
      }).FirstOrDefaultAsync(cancellationToken);

        if(data == null)
            {
                return Response<VehicleDto>.Failure(
                    $"Vehicle with ID '{request.Id}' was not found",
                    "VEHICLE_NOT_FOUND" // Optional error code
                );
            } 

        return Response<VehicleDto>.Success(data,"");
    }
  }
}