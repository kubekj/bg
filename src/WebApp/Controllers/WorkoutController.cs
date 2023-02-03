using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.Workout;
using Application.DTO.Entities;
using Application.Queries.Workouts;
using Application.Queries.Workouts.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("api/workouts")]
public class WorkoutController : ApiController
{
    private readonly ICommandHandler<CreateWorkoutCommand> _createWorkoutCommandHandler;
    private readonly ICommandHandler<EditWorkoutCommand> _editWorkoutCommandHandler;
    private readonly ICommandHandler<CreateWorkoutSessionCommand> _createWorkoutSessionCommandHandler;
    private readonly IQueryHandler<GetWorkoutsQuery, IEnumerable<WorkoutDto>> _getWorkoutsQueryHandler;
    private readonly IQueryHandler<GetWorkoutQuery, WorkoutDto> _getWorkoutQueryHandler;
    private readonly IQueryHandler<GetCurrentWorkoutQuery,WorkoutDto> _getCurrentWorkoutQueryHandler;
    private readonly IQueryHandler<GetPreviousWorkoutQuery,WorkoutDto> _getPreviousWorkoutQueryHandler;
    private readonly IQueryHandler<GetNextWorkoutQuery,WorkoutDto> _getNextWorkoutQueryHandler;
    private Guid _userId;

    public WorkoutController(ICommandHandler<CreateWorkoutCommand> createWorkoutCommandHandler,
        ICommandHandler<EditWorkoutCommand> editWorkoutCommandHandler, 
        ICommandHandler<CreateWorkoutSessionCommand> createWorkoutSessionCommandHandler,
        IQueryHandler<GetWorkoutsQuery, IEnumerable<WorkoutDto>> getWorkoutsQueryHandler, 
        IQueryHandler<GetWorkoutQuery, WorkoutDto> getWorkoutQueryHandler, 
        IQueryHandler<GetCurrentWorkoutQuery, WorkoutDto> getCurrentWorkoutQueryHandler, 
        IQueryHandler<GetPreviousWorkoutQuery, WorkoutDto> getPreviousWorkoutQueryHandler, 
        IQueryHandler<GetNextWorkoutQuery, WorkoutDto> getNextWorkoutQueryHandler)
    {
        _createWorkoutCommandHandler = createWorkoutCommandHandler;
        _editWorkoutCommandHandler = editWorkoutCommandHandler;
        _createWorkoutSessionCommandHandler = createWorkoutSessionCommandHandler;
        _getWorkoutsQueryHandler = getWorkoutsQueryHandler;
        _getWorkoutQueryHandler = getWorkoutQueryHandler;
        _getCurrentWorkoutQueryHandler = getCurrentWorkoutQueryHandler;
        _getPreviousWorkoutQueryHandler = getPreviousWorkoutQueryHandler;
        _getNextWorkoutQueryHandler = getNextWorkoutQueryHandler;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateWorkoutCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createWorkoutCommandHandler.HandleAsync(command with {UserId = _userId});
        return NoContent();
    }
    
    [HttpPost("assign")]
    public async Task<ActionResult> Post(CreateWorkoutSessionCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createWorkoutSessionCommandHandler.HandleAsync(command with {UserId = _userId});
        return NoContent();
    }
    
        
    [HttpGet("current")]
    public async Task<ActionResult> GetCurrent()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getCurrentWorkoutQueryHandler.HandleAsync(new GetCurrentWorkoutQuery(_userId));
        return Ok(result);
    }

    [HttpGet("previous")]
    public async Task<ActionResult> GetPrevious()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getPreviousWorkoutQueryHandler.HandleAsync(new GetPreviousWorkoutQuery(_userId));
        return Ok(result);
    }

    [HttpGet("next")]
    public async Task<ActionResult> GetNext()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getNextWorkoutQueryHandler.HandleAsync(new GetNextWorkoutQuery(_userId));
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getWorkoutsQueryHandler.HandleAsync(new GetWorkoutsQuery(_userId));
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getWorkoutQueryHandler.HandleAsync(new GetWorkoutQuery(_userId,id));
        return Ok(result);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(EditWorkoutCommand editWorkoutCommand, Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _editWorkoutCommandHandler.HandleAsync(editWorkoutCommand with{UserId = _userId, WorkoutId = id});
        return NoContent();
    }
}