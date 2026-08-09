using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Vehicles.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<List<GetCategoryDto>>>
    {
    private readonly IApplicationDbContext _context;
        public GetCategoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context; 
        }

    public async Task<Response<List<GetCategoryDto>>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
      var data = await _context.VehicleCategories
      .Include(x=>x.Vehicles)
      .Where(x=>x.Id == request.CategoryId)
      .Select(x => new GetCategoryDto
      {  
          CategoryId = x.Id,
          Name = x.Name,
          Description = x.Description,
          CreatedAt = x.CreatedAt
      })
      .ToListAsync(cancellationToken);

      return Response<List<GetCategoryDto>>.Success(data, "Vehicle categories retrieved successfully.");
    }
  }
}