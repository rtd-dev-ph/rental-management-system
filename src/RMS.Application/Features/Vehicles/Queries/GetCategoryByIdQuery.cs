using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Vehicles.Queries
{
    public class GetCategoryByIdQuery : IRequest<Response<List<GetCategoryDto>>>
    {
        public int CategoryId { get; set; }
    } 
}