using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Features.Dto;
using RMS.Application.Features.Reservations.Commands.CreateReservation;
using RMS.Application.Features.Reservations.Queries.GetReservation;
using RMS.Application.Features.Reservations.Queries.GetReservationById;

namespace RMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : BaseApiController
    {
    private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpPost]
        public async Task<IActionResult>CreateReservation([FromBody] CreateReservationCommand command)
        {
            var reservation = await _mediator.Send(command);
            return HandleResponse(reservation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservation()
        {
            var reservation = await _mediator.Send(new GetReservationQuery());
            return HandleResponse(reservation);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllReservation(Guid id)
        {
            var reservation = await _mediator.Send(new GetReservationByIdQuery {Id = id});
            return HandleResponse(reservation);
        }
 
    }
}