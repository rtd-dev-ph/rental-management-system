using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Features.Dto;
using RMS.Application.Features.Vehicles.Commands.CreateCategory;
using RMS.Application.Features.Vehicles.Commands.CreateVehicle;
using RMS.Application.Features.Vehicles.Commands.GetCategory;
using RMS.Application.Features.Vehicles.Commands.GetVehicle;

namespace RMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
            var results= await _mediator.Send(new GetVehicleCommand());
            return Ok(results);
    }   

    [HttpPost]
    public async Task<IActionResult>Create([FromBody] CreateVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
  

    [HttpPost("category")]
    public async Task<IActionResult>CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    [HttpGet("category")]
    public async Task<IActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetCategoryCommand());
            return Ok(result);
        }
    }
}