using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMS.Application.Features.Dashboard.Queries.GetStats;

namespace RMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : BaseApiController
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var result = await _mediator.Send(new GetStatsQuery());
        return HandleResponse(result);
    }
}
