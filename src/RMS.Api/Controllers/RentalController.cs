using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Features.Rentals.Commands.PickupVehicle;
using RMS.Application.Features.Rentals.Commands.PickupVehicle.Queries;
using RMS.Application.Features.Rentals.Commands.ReturnVehicle;
using RMS.Application.Features.Rentals.Queries;

namespace RMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : BaseApiController
    {
    private readonly IMediator _mediator;
        public RentalController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost("{reservationId}/pickup")]
        public async Task<IActionResult>PickUpVehicle(Guid reservationId, [FromBody] PickupVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResponse(result);
        } 
 
        [HttpGet]
        public async Task<IActionResult> GetAllRentalTransactions()
        {
            var result = await _mediator.Send(new GetAllRentalTransactionsQuery());
            return HandleResponse(result);
        } 

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveRentalTransactions()
        {
            var result = await _mediator.Send(new GetActiveRentalsQuery());
            return HandleResponse(result);
        }

        [HttpPut("{rentalId}/rental")]
        public async Task<IActionResult> ReturnVehicle(Guid rentalId, [FromBody] ReturnVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return HandleResponse(result);
        }
    }
}