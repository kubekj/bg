using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.User;
using Application.Commands.User.Handlers;
using Application.DTO;
using Application.DTO.Entities;
using Application.Queries.User;
using Application.Security;
using Core.ValueObjects.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/users")]
public class UserController : ApiController
{
    private readonly ITokenStorage _tokenStorage;
    private readonly ICommandHandler<SignUpCommand> _signUpCommandHandler;
    private readonly ICommandHandler<SignInCommand> _signInCommandHandler;
    private readonly ICommandHandler<ChangeUserDetailsCommand> _changeUserDetailsCommandHandler;
    private readonly ICommandHandler<SignUpAsCoachCommand> _signUpAsCoachCommandHandler;
    private readonly IQueryHandler<GetPersonalInfoQuery,UserDto> _getPersonalInfoQueryHandler;
    private readonly IQueryHandler<GetTrainerInfoQuery,TrainerDto> _getTrainerInfoQueryHandler;
    
    public UserController(ICommandHandler<SignUpCommand> signUpCommandHandler, 
        ICommandHandler<SignInCommand> signInCommandHandler, ITokenStorage tokenStorage, 
        ICommandHandler<ChangeUserDetailsCommand> changeUserDetailsCommandHandler, 
        IQueryHandler<GetPersonalInfoQuery, UserDto> getPersonalInfoQueryHandler,
        ICommandHandler<SignUpAsCoachCommand> signUpAsCoachCommandHandler, 
        IQueryHandler<GetTrainerInfoQuery, TrainerDto> getTrainerInfoQueryHandler)
    {
        _signUpCommandHandler = signUpCommandHandler;
        _signInCommandHandler = signInCommandHandler;
        _tokenStorage = tokenStorage;
        _changeUserDetailsCommandHandler = changeUserDetailsCommandHandler;
        _getPersonalInfoQueryHandler = getPersonalInfoQueryHandler;
        _signUpAsCoachCommandHandler = signUpAsCoachCommandHandler;
        _getTrainerInfoQueryHandler = getTrainerInfoQueryHandler;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        await _signUpCommandHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPost("signin")]
    public async Task<ActionResult<JwtDto>> SignIn(SignInCommand command)
    {
        await _signInCommandHandler.HandleAsync(command);
        return Ok(_tokenStorage.Get());
    }

    [Authorize]
    [HttpPut("details")]
    public async Task<ActionResult> ChangeDetails(ChangeUserDetailsCommand command)
    {
        var userId = Guid.Parse(HttpContext.User.Identity?.Name);
        await _changeUserDetailsCommandHandler.HandleAsync(command with {UserId = userId});
        return NoContent();
    }
    
    [Authorize(Roles = "athlete")]
    [HttpPut("trainer")]
    public async Task<ActionResult> RegisterAsTrainer()
    {
        var userId = Guid.Parse(HttpContext.User.Identity?.Name);
        await _signUpAsCoachCommandHandler.HandleAsync(new SignUpAsCoachCommand(UserId: userId));
        return NoContent();
    }
    
    [Authorize]
    [HttpGet("details")]
    public async Task<ActionResult> GetDetails()
    {
        var userId = Guid.Parse(HttpContext.User.Identity?.Name);
        var result = await _getPersonalInfoQueryHandler.HandleAsync(new GetPersonalInfoQuery(UserId: userId));
        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("trainer-details/{email}")]
    public async Task<ActionResult> GetTrainerDetails(string email)
    {
        var result = await _getTrainerInfoQueryHandler.HandleAsync(new GetTrainerInfoQuery(email));
        return Ok(result);
    }
}