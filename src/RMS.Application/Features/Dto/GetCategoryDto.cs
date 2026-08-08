using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Application.Features.Dto
{
    public class GetCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;  // Motorcycle, Sedan, SUV, Van
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}