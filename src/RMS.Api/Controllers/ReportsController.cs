using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Features.Reports.Queries.GetRevenue;

namespace RMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("revenue")]
    public async Task<IActionResult> GetRevenue([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
       var result = await _mediator.Send(new GetRevenueQuery 
    { 
        FromDate = DateTime.SpecifyKind(fromDate, DateTimeKind.Utc),
        ToDate = DateTime.SpecifyKind(toDate, DateTimeKind.Utc)
    });
    return HandleResponse(result);
    }
}
