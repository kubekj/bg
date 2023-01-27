using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.TrainingPlan;
using Application.DTO.Entities;
using Application.Queries.TrainingPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
[Route("training-plans")]
public class TrainingPlanController : ApiController
{
    private readonly ICommandHandler<CreateTrainingPlanCommand> _createTrainingCommandHandler;
    private readonly IQueryHandler<GetAllTrainingPlansQuery,IEnumerable<TrainingPlanDto>> _getAllTrainingPlansQueryHandler;
    private Guid _userId;
    public TrainingPlanController(ICommandHandler<CreateTrainingPlanCommand> createTrainingCommandHandler,
        IQueryHandler<GetAllTrainingPlansQuery, IEnumerable<TrainingPlanDto>> getAllTrainingPlansQueryHandler)
    {
        _createTrainingCommandHandler = createTrainingCommandHandler;
        _getAllTrainingPlansQueryHandler = getAllTrainingPlansQueryHandler;
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
        var result = await _getAllTrainingPlansQueryHandler.HandleAsync(new GetAllTrainingPlansQuery());
        return Ok(result);
    }
}