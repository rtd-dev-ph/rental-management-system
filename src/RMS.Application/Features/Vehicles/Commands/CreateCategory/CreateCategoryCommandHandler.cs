using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Interfaces;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Commands.CreateCategory
{
  public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
  {
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
       var category = new VehicleCategory()
       { 
        Name = request.Name,
        Description = request.Description,
        CreatedAt = DateTime.UtcNow 
       };

        await _context.VehicleCategories.AddAsync(category);
        await _context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
  }
}