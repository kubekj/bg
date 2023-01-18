using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.Workout;
using Application.DTO.Entities;
using Application.Queries.Workouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("workouts")]
public class WorkoutController : ApiController
{
    private readonly ICommandHandler<CreateWorkoutCommand> _createExerciseCommandHandler;
    private readonly IQueryHandler<GetWorkoutsQuery, IEnumerable<WorkoutDto>> _getWorkoutsQueryHandler;
    private readonly IQueryHandler<GetWorkoutQuery, WorkoutDto> _getWorkoutQueryHandler;
    private Guid _userId;

    public WorkoutController(ICommandHandler<CreateWorkoutCommand> createExerciseCommandHandler, 
        IQueryHandler<GetWorkoutsQuery, IEnumerable<WorkoutDto>> getWorkoutsQueryHandler, 
        IQueryHandler<GetWorkoutQuery, WorkoutDto> getWorkoutQueryHandler)
    {
        _createExerciseCommandHandler = createExerciseCommandHandler;
        _getWorkoutsQueryHandler = getWorkoutsQueryHandler;
        _getWorkoutQueryHandler = getWorkoutQueryHandler;
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateWorkoutCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createExerciseCommandHandler.HandleAsync(command with {UserId = _userId});
        return NoContent();
    }
    
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getWorkoutsQueryHandler.HandleAsync(new GetWorkoutsQuery(_userId));
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get(Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getWorkoutQueryHandler.HandleAsync(new GetWorkoutQuery(_userId,id));
        return Ok(result);
    }
}