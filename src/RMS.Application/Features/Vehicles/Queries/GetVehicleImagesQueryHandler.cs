using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Queries
{
  public class GetVehicleImagesQueryHandler : IRequestHandler<GetVehicleImagesQuery, Response<List<VehicleImage>>>
    { 
    private readonly IApplicationDbContext _context;
        public GetVehicleImagesQueryHandler(IApplicationDbContext context)
        {
             _context = context;
            
        }  

    public async Task<Response<List<VehicleImage>>> Handle(GetVehicleImagesQuery request, CancellationToken cancellationToken)
    {
       var vehicleImages = await _context.VehicleImages
       .Where(x=>x.VehicleId == request.VehicleId)
       .OrderByDescending(x=>x.IsCover)
       .ThenBy(x=>x.SortOrder)
       .ToListAsync(cancellationToken);

       if(vehicleImages == null || vehicleImages.Count <= 0)
        return Response<List<VehicleImage>>.Failure("No image found.");

       return Response<List<VehicleImage>>.Success(vehicleImages);
    }

    
 

  }
}