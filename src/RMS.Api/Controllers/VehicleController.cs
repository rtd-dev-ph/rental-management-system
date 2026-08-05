using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Common.Models;
using RMS.Application.Features.Dto;
using RMS.Application.Features.Vehicles.Commands.CreateCategory;
using RMS.Application.Features.Vehicles.Commands.CreateVehicle;
using RMS.Application.Features.Vehicles.Commands.DeleteVehicle;
using RMS.Application.Features.Vehicles.Commands.GetCategory;
using RMS.Application.Features.Vehicles.Commands.GetVehicle;
using RMS.Application.Features.Vehicles.Commands.UpdateVehicle;
using RMS.Application.Features.Vehicles.Commands.UploadImage;

namespace RMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : BaseApiController
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicleById(Guid id)
        {
            var result = await _mediator.Send(new GetVehicleById {Id = id});
            
            return HandleResponse(result);
        } 

    [HttpPost]
    public async Task<IActionResult>Create([FromBody] CreateVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
  
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, [FromBody] UpdateVehicle command)
        {
            if(id != command.Id)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "ID in URL does not match ID in request body.",
                    ErrorCode = "ID_MISMATCH"
                });
            }
            var result = await _mediator.Send(command);
            return HandleResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var result = await _mediator.Send(new DeleteVehicle {Id = id}); 
            return HandleResponse(result);
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

    [HttpPost("{id}/images")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage(Guid id, [FromForm] UploadImageRequest request)
    {
        var command = new UploadImageCommand
        {
            VehicleId = id,
            File = request.File,
            IsCover = request.IsCover
        };
        var result = await _mediator.Send(command);
        return HandleResponse(result);
    }

    public class UploadImageRequest
    {
        public IFormFile File { get; set; } = null!;
        public bool IsCover { get; set; }
    }

    } 
}