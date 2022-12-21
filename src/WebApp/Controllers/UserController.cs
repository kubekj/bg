using Application.Abstractions.Messaging.Command;
using Application.Commands.User;
using Application.DTO;
using Application.Security;
using Microsoft.AspNetCore.Mvc;
using WebApp.Abstraction;

namespace WebApp.Controllers;

[Route("user")]
public class UserController : ApiController
{
    private readonly ITokenStorage _tokenStorage;
    private readonly ICommandHandler<SignUpCommand> _signUpCommandHandler;
    private readonly ICommandHandler<SignInCommand> _signInCommandHandler;
    
    public UserController(ICommandHandler<SignUpCommand> signUpCommandHandler, ICommandHandler<SignInCommand> signInCommandHandler, ITokenStorage tokenStorage)
    {
        _signUpCommandHandler = signUpCommandHandler;
        _signInCommandHandler = signInCommandHandler;
        _tokenStorage = tokenStorage;
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
}