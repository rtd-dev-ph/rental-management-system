using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Features.Dto;

namespace RMS.Application.Features.Vehicles.Commands.GetCategory
{
    public record GetCategoryCommand : IRequest<List<GetCategoryDto>>; 
}