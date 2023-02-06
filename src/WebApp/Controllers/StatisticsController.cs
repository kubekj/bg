using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.Goals;
using Application.Queries.Statistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("api/statistics")]
public class StatisticsController : ApiController
{
    private readonly IQueryHandler<GetWeightAvgByMonthQuery,IDictionary<string,double>> _getWeightAvgByMonthQueryHandler;
    private readonly IQueryHandler<GetTrainingsDoneThisMonthQuery,Tuple<int,int>> _getTrainingsDoneThisMonthQueryHandler;
    private readonly ICommandHandler<SetGoalCommand> _setGoalCommandHandler;
    private Guid _userId;
    public StatisticsController(IQueryHandler<GetWeightAvgByMonthQuery, IDictionary<string, double>> getWeightAvgByMonthQueryHandler,
        ICommandHandler<SetGoalCommand> setGoalCommandHandler, 
        IQueryHandler<GetTrainingsDoneThisMonthQuery, Tuple<int, int>> getTrainingsDoneThisMonthQueryHandler)
    {
        _getWeightAvgByMonthQueryHandler = getWeightAvgByMonthQueryHandler;
        _setGoalCommandHandler = setGoalCommandHandler;
        _getTrainingsDoneThisMonthQueryHandler = getTrainingsDoneThisMonthQueryHandler;
    }

    [HttpGet("weight")]
    public async Task<ActionResult> GetAvgWeightGroupedByMonth()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getWeightAvgByMonthQueryHandler.HandleAsync(new GetWeightAvgByMonthQuery(_userId));
        return Ok(result);
    }
    
    [HttpGet("trainings")]
    public async Task<ActionResult> GetTrainingsDoneThisMonth()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getTrainingsDoneThisMonthQueryHandler.HandleAsync(new GetTrainingsDoneThisMonthQuery(_userId));
        return Ok(result);
    }
    
    [HttpPost("goal")]
    public async Task<ActionResult> SetGoal(SetGoalCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _setGoalCommandHandler.HandleAsync(command with {UserId = _userId});
        return NoContent();
    }
    
    
}