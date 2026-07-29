using Microsoft.AspNetCore.Mvc;
using RMS.Application.Common.Models;

namespace RMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult HandleResponse<T>(Response<T> response)
        {
            if (!response.IsSuccess)
            {
                return response.ErrorCode switch
                {
                    "VEHICLE_NOT_FOUND" => NotFound(new
                    {
                        response.IsSuccess,
                        response.Message,
                        response.ErrorCode
                    }),
                    "VALIDATION_ERROR" => BadRequest(new
                    {
                        response.IsSuccess,
                        response.Message,
                        response.ErrorCode
                    }),
                    _ => StatusCode(500, new
                    {
                        response.IsSuccess,
                        response.Message,
                        response.ErrorCode
                    })
                };
            }

            return Ok(new
            {
                response.IsSuccess,
                response.Message,
                response.Data
            });
        }

        protected IActionResult HandleResponse(Response response)
        {
            if (!response.IsSuccess)
            {
                return BadRequest(new
                {
                    response.IsSuccess,
                    response.Message,
                    response.ErrorCode
                });
            }

            return Ok(new
            {
                response.IsSuccess,
                response.Message
            });
        }
    }
}