using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;

namespace RMS.Application.Features.Vehicles.Commands.GetVehicle
{
  public class GetVehicleCommandHandler : IRequestHandler<GetVehicleCommand, List<VehicleDto>>
  {
    private readonly IApplicationDbContext _context;

    public GetVehicleCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }    
    public async Task<List<VehicleDto>> Handle(GetVehicleCommand request, CancellationToken cancellationToken)
    {
        var data = await _context.Vehicles
       .Include(x => x.Category)
       .Include(x=>x.Images)
       .Select(x => new VehicleDto
       {
           Id = x.Id,
           Brand = x.Brand,
           Model = x.Model,
           Year = x.Year,
           PlateNumber = x.PlateNumber,
           DailyRate = x.DailyRate,
           Status = x.Status,
           CategoryName = x.Category.Name,  
           ImageUrl = x.Images
            .Where(i=>i.IsCover)
            .Select(i=>i.FilePath)
            .FirstOrDefault()
       })
       .ToListAsync(cancellationToken);
 
        return data;
    }
  }
}