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
    private readonly ICommandHandler<BuyTrainingPlanCommand> _buyTrainingCommandHandler;
    private readonly ICommandHandler<ApplyTrainingPlanCommand> _applyTrainingCommandHandler;
    private readonly ICommandHandler<EditTrainingPlanCommand> _editTrainingCommandHandler;
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
        ICommandHandler<RateTrainingPlanCommand> rateTrainingCommandHandler, 
        ICommandHandler<BuyTrainingPlanCommand> buyTrainingCommandHandler, 
        ICommandHandler<ApplyTrainingPlanCommand> applyTrainingCommandHandler, 
        ICommandHandler<EditTrainingPlanCommand> editTrainingCommandHandler)
    {
        _createTrainingCommandHandler = createTrainingCommandHandler;
        _getAllTrainingPlansQueryHandler = getAllTrainingPlansQueryHandler;
        _getAllBoughtTrainingPlansQueryHandler = getAllBoughtTrainingPlansQueryHandler;
        _getAllCreatedTrainingPlansQueryHandler = getAllCreatedTrainingPlansQueryHandler;
        _getTrainingPlanQueryHandler = getTrainingPlanQueryHandler;
        _getMostRecentlyCreatedPlansQueryQueryHandler = getMostRecentlyCreatedPlansQueryQueryHandler;
        _rateTrainingCommandHandler = rateTrainingCommandHandler;
        _buyTrainingCommandHandler = buyTrainingCommandHandler;
        _applyTrainingCommandHandler = applyTrainingCommandHandler;
        _editTrainingCommandHandler = editTrainingCommandHandler;
    }
    
    // [Authorize(Roles = "trainer")]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateTrainingPlanCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createTrainingCommandHandler.HandleAsync(command with {AuthorId = _userId});
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Edit(EditTrainingPlanCommand command, Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _editTrainingCommandHandler.HandleAsync(command with {UserId = _userId, TrainingId = id});
        return NoContent();
    }
    
    [HttpPost("rate/{id:guid}")]
    public async Task<ActionResult> Rate(RateTrainingPlanCommand command, Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _rateTrainingCommandHandler.HandleAsync(command with {UserId = _userId, TrainingPlanId = id});
        return NoContent();
    }
    
    [HttpPost("buy/{id:guid}")]
    public async Task<ActionResult> Rate( Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _buyTrainingCommandHandler.HandleAsync(new BuyTrainingPlanCommand(UserId: _userId, TrainingPlanId: id));
        return NoContent();
    }
    
    [HttpPost("apply/{id:guid}")]
    public async Task<ActionResult> Apply(Guid id, ApplyTrainingPlanCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _applyTrainingCommandHandler.HandleAsync(command with {UserId = _userId, TrainingPlanId = id});
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = 
            await _getAllTrainingPlansQueryHandler.HandleAsync(new GetAllTrainingPlansQuery(_userId));
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
    
    [HttpGet("most-recent-trainings/{email}")]
    public async Task<ActionResult> GetMostRecentTrainings(string email)
    {
        var result = 
            await _getMostRecentlyCreatedPlansQueryQueryHandler.HandleAsync(new GetMostRecentlyCreatedPlansQuery(email));
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