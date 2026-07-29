using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace RMS.Application.Features.Vehicles.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;  // Motorcycle, Sedan, SUV, Van
        public string? Description { get; set; } 
    }
}