using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;

namespace RMS.Application.Features.Vehicles.Commands.DeleteVehicle
{
  public class DeleteVehicleHandler : IRequestHandler<DeleteVehicle, Response<string>>
  {
    private readonly IApplicationDbContext _context;

    public DeleteVehicleHandler(IApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Response<string>> Handle(DeleteVehicle request, CancellationToken cancellationToken)
    {
       var deleteVehicle = await _context.Vehicles.FirstOrDefaultAsync(x=>x.Id.Equals(request.Id));

        if(deleteVehicle == null)
            {
                return Response<string>.Failure("Vehicle not found.","INVALID_INPUT");
            }

       deleteVehicle.DeletedAt = DateTime.UtcNow; //Soft Delete
       await _context.SaveChangesAsync(cancellationToken);

       return Response<string>.Success("Deleted sucessfully.");
    }
  }
}