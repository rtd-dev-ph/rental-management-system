using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Rentals.Commands.PickupVehicle.Queries
{
    public record GetAllRentalTransactionsQuery: IRequest<Response<List<GetRentalTransactionsDto>>>;
}