using Application.Abstractions.Messaging.Command;
using Application.Commands.TrainingPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("training-plans")]
public class TrainingPlanController : ApiController
{
    private readonly ICommandHandler<CreateTrainingPlanCommand> _createTrainingCommandHandler;
    private Guid _userId;
    public TrainingPlanController(ICommandHandler<CreateTrainingPlanCommand> createTrainingCommandHandler)
    {
        _createTrainingCommandHandler = createTrainingCommandHandler;
    }
    
    [Authorize(Roles = "trainer")]
    [HttpPost("create")]
    public async Task<ActionResult> Post(CreateTrainingPlanCommand command)
    {
        _userId = Guid.Parse(HttpContext.User.Identity.Name);
        await _createTrainingCommandHandler.HandleAsync(command with {AuthorId = _userId});
        return NoContent();
    }
}