using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Vehicles.Commands.DeleteImage
{
  public class DeleteImagesCommandHandler : IRequestHandler<DeleteImagesCommand, Response<string>>
  {
    private readonly IApplicationDbContext _context;
    private readonly IHostEnvironment _env; 

    public DeleteImagesCommandHandler(IApplicationDbContext context, IHostEnvironment env)
    { 
      _context = context;
      _env = env;
    }

    public async Task<Response<string>> Handle(DeleteImagesCommand request, CancellationToken cancellationToken)
    {
       var image = await _context.VehicleImages
       .FirstOrDefaultAsync(x=>x.Id == request.ImageId, cancellationToken);

       if(image == null)
        return Response<string>.Failure("Image not found.");

        var filePath = Path.Combine(_env.ContentRootPath, "wwwroot", image.FilePath.TrimStart('/'));

        if (File.Exists(filePath))
            File.Delete(filePath);

        _context.VehicleImages.Remove(image);
        await _context.SaveChangesAsync(cancellationToken);

        return Response<string>.Success("Image deleted");
    }
  }
}