using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.TrainingPlan;
using Application.DTO.Entities;
using Application.Queries.TrainingPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("api/training-plans")]
public class TrainingPlanController : ApiController
{
    private readonly ICommandHandler<CreateTrainingPlanCommand> _createTrainingCommandHandler;
    private readonly ICommandHandler<RateTrainingPlanCommand> _rateTrainingCommandHandler;
    private readonly IQueryHandler<GetAllTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllTrainingPlansQueryHandler;
    private readonly IQueryHandler<GetBoughtTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllBoughtTrainingPlansQueryHandler;
    private readonly IQueryHandler<GetCreatedTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllCreatedTrainingPlansQueryHandler;
    private readonly IQueryHandler<GetTrainingPlanQuery,TrainingPlanDto> _getTrainingPlanQueryHandler;
    private readonly IQueryHandler<GetMostRecentlyCreatedPlansQuery,IEnumerable<TrainingPlanDto>> _getMostRecentlyCreatedPlansQueryQueryHandler;
    private Guid _userId;
    public TrainingPlanController(ICommandHandler<CreateTrainingPlanCommand> createTrainingCommandHandler,
        IQueryHandler<GetAllTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllTrainingPlansQueryHandler,
        IQueryHandler<GetBoughtTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllBoughtTrainingPlansQueryHandler,
        IQueryHandler<GetCreatedTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllCreatedTrainingPlansQueryHandler, 
        IQueryHandler<GetTrainingPlanQuery, TrainingPlanDto> getTrainingPlanQueryHandler, 
        IQueryHandler<GetMostRecentlyCreatedPlansQuery, IEnumerable<TrainingPlanDto>> getMostRecentlyCreatedPlansQueryQueryHandler,
        ICommandHandler<RateTrainingPlanCommand> rateTrainingCommandHandler)
    {
        _createTrainingCommandHandler = createTrainingCommandHandler;
        _getAllTrainingPlansQueryHandler = getAllTrainingPlansQueryHandler;
        _getAllBoughtTrainingPlansQueryHandler = getAllBoughtTrainingPlansQueryHandler;
        _getAllCreatedTrainingPlansQueryHandler = getAllCreatedTrainingPlansQueryHandler;
        _getTrainingPlanQueryHandler = getTrainingPlanQueryHandler;
        _getMostRecentlyCreatedPlansQueryQueryHandler = getMostRecentlyCreatedPlansQueryQueryHandler;
        _rateTrainingCommandHandler = rateTrainingCommandHandler;
    }
    
    [Authorize(Roles = "trainer")]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateTrainingPlanCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createTrainingCommandHandler.HandleAsync(command with {AuthorId = _userId});
        return NoContent();
    }
    
    [HttpPost("rate/{id:guid}")]
    public async Task<ActionResult> Rate(RateTrainingPlanCommand command, Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _rateTrainingCommandHandler.HandleAsync(command with {UserId = _userId, TrainingPlanId = id});
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = 
            await _getAllTrainingPlansQueryHandler.HandleAsync(new GetAllTrainingPlansQuery());
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetSingle(Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getTrainingPlanQueryHandler.HandleAsync(new GetTrainingPlanQuery(_userId,id));
        return Ok(result);
    }
    
    [HttpGet("most-recent-trainings/{id:guid}")]
    public async Task<ActionResult> GetMostRecentTrainings(Guid id)
    {
        var result = 
            await _getMostRecentlyCreatedPlansQueryQueryHandler.HandleAsync(new GetMostRecentlyCreatedPlansQuery(id));
        return Ok(result);
    }
    
    [HttpGet("created")]
    public async Task<ActionResult> GetAllCreated()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getAllCreatedTrainingPlansQueryHandler.HandleAsync(new GetCreatedTrainingPlansQuery(_userId));
        return Ok(result);
    }
    
    [HttpGet("bought")]
    public async Task<ActionResult> GetAllBought()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getAllBoughtTrainingPlansQueryHandler.HandleAsync(new GetBoughtTrainingPlansQuery(_userId));
        return Ok(result);
    }
}