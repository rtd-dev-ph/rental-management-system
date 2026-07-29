using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Vehicles.Commands.GetCategory
{
  public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, List<GetCategoryDto>>
  {
    private readonly IApplicationDbContext _context;

    public GetCategoryCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<List<GetCategoryDto>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
    {
      var data = await _context.VehicleCategories
      .Include(x=>x.Vehicles)
      .Select(x => new GetCategoryDto
      {  
          Name = x.Name,
          Description = x.Description,
          CreatedAt = x.CreatedAt
      })
      .ToListAsync(cancellationToken);

      return data;
    }
  }
}