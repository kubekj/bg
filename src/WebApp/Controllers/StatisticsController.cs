using Application.Abstractions.Messaging.Query;
using Application.Queries.Statistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("statistics")]
public class StatisticsController : ApiController
{
    private readonly IQueryHandler<GetWeightAvgByMonthQuery,IDictionary<string,double>> _getWeightAvgByMonthQueryHandler;
    private Guid _userId;
    public StatisticsController(IQueryHandler<GetWeightAvgByMonthQuery, IDictionary<string, double>> getWeightAvgByMonthQueryHandler)
    {
        _getWeightAvgByMonthQueryHandler = getWeightAvgByMonthQueryHandler;
    }

    [HttpGet("weight")]
    public async Task<ActionResult> GetAvgWeightGroupedByMonth()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getWeightAvgByMonthQueryHandler.HandleAsync(new GetWeightAvgByMonthQuery(_userId));
        return Ok(result);
    }
}