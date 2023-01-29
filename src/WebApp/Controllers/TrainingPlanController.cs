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
    private readonly IQueryHandler<GetAllTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllTrainingPlansQueryHandler;
    private readonly IQueryHandler<GetBoughtTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllBoughtTrainingPlansQueryHandler;
    private readonly IQueryHandler<GetCreatedTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllCreatedTrainingPlansQueryHandler;
    private Guid _userId;
    public TrainingPlanController(ICommandHandler<CreateTrainingPlanCommand> createTrainingCommandHandler,
        IQueryHandler<GetAllTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllTrainingPlansQueryHandler,
        IQueryHandler<GetBoughtTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllBoughtTrainingPlansQueryHandler,
        IQueryHandler<GetCreatedTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllCreatedTrainingPlansQueryHandler)
    {
        _createTrainingCommandHandler = createTrainingCommandHandler;
        _getAllTrainingPlansQueryHandler = getAllTrainingPlansQueryHandler;
        _getAllBoughtTrainingPlansQueryHandler = getAllBoughtTrainingPlansQueryHandler;
        _getAllCreatedTrainingPlansQueryHandler = getAllCreatedTrainingPlansQueryHandler;
    }
    
    [Authorize(Roles = "trainer")]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateTrainingPlanCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createTrainingCommandHandler.HandleAsync(command with {AuthorId = _userId});
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = 
            await _getAllTrainingPlansQueryHandler.HandleAsync(new GetAllTrainingPlansQuery());
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