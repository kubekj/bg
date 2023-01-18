using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.Exercise;
using Application.DTO.Entities;
using Application.Queries.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("exercises")]
public class ExerciseController : ApiController
{
    private readonly ICommandHandler<CreateExerciseCommand> _createExerciseCommandHandler;
    private readonly IQueryHandler<GetExercisesQuery,IEnumerable<ExerciseDto>> _getExercisesQueryHandler;
    private readonly IQueryHandler<GetExerciseQuery,ExerciseDto> _getExerciseQueryHandler;
    private Guid _userId;

    public ExerciseController(ICommandHandler<CreateExerciseCommand> createExerciseCommandHandler, IQueryHandler<GetExercisesQuery, IEnumerable<ExerciseDto>> getExercisesQueryHandler, IQueryHandler<GetExerciseQuery, ExerciseDto> getExerciseQueryHandler)
    {
        _createExerciseCommandHandler = createExerciseCommandHandler;
        _getExercisesQueryHandler = getExercisesQueryHandler;
        _getExerciseQueryHandler = getExerciseQueryHandler;
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateExerciseCommand command)
    {
        await _createExerciseCommandHandler.HandleAsync(command);
        return NoContent();
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getExercisesQueryHandler.HandleAsync(new GetExercisesQuery(_userId));
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetSpecific(Guid id)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        var result = await _getExerciseQueryHandler.HandleAsync(new GetExerciseQuery(_userId,id));
        return Ok(result);
    }
    
}