using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Rentals.Queries
{
    public record GetActiveRentalsQuery : IRequest<Response<List<RentalTransaction>>>;
}