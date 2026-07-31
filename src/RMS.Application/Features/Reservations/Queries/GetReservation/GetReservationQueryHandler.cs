using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Reservations.Queries.GetReservation
{
  public class GetReservationQueryHandler :  IRequestHandler<GetReservationQuery, Response<List<GetReservationDto>>>
  {
    private readonly IApplicationDbContext _context;
    public GetReservationQueryHandler(IApplicationDbContext context)
    {
     _context = context;
        
    }
    public  async Task<Response<List<GetReservationDto>>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
       var data = await _context.Reservations
       .Include(x=>x.Vehicle)
       .Include(x=>x.Customer)
       .Select(x => new GetReservationDto
       {
        CustomerId = x.Customer.Id,
        VehicleId = x.VehicleId,
        StartDate = x.StartDate,
        EndDate = x.EndDate,
        Status = x.Status,
        TotalAmount = x.TotalAmount,
        Notes = x.Notes,
        CreatedAt = x.CreatedAt,
        UpdatedAt = x.UpdatedAt,
        Brand = x.Vehicle.Brand,
        Model = x.Vehicle.Model,
        Year = x.Vehicle.Year,
        PlateNumber = x.Vehicle.PlateNumber,
        DailyRate = x.Vehicle.DailyRate,
        Email = x.Customer.Email,
        FirstName = x.Customer.FirstName,
        LastName = x.Customer.LastName
       })
       .ToListAsync(cancellationToken);

       if(data == null || data.Count < 0)
         return Response<List<GetReservationDto>>.Failure("No records found.");
 
       return Response<List<GetReservationDto>>.Success(data);
    } 
  }
}