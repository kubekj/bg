using Application.Abstractions.Messaging.Command;
using Application.Commands.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Abstraction;

namespace WebApp.Controllers;

[Route("exercises")]
public class ExerciseController : ApiController
{
    private readonly ICommandHandler<CreateExerciseCommand> _createExerciseCommandHandler;

    public ExerciseController(ICommandHandler<CreateExerciseCommand> createExerciseCommandHandler)
    {
        _createExerciseCommandHandler = createExerciseCommandHandler;
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateExerciseCommand command)
    {
        await _createExerciseCommandHandler.HandleAsync(command);
        return NoContent();
    }

    [Authorize]
    [HttpGet("get")]
    public async Task<ActionResult> Get()
    {
        return Ok();
    }
}