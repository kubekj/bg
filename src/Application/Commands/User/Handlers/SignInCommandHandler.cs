using System.Security.Authentication;
using Application.Abstractions.Messaging.Command;
using Application.Security;
using Core.Repositories;

namespace Application.Commands.User.Handlers;

public class SignInCommandHandler : ICommandHandler<SignInCommand>
{
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;
    private readonly IUserRepository _userRepository;

    public SignInCommandHandler(IUserRepository userRepository, IPasswordManager passwordManager,
        IAuthenticator authenticator, ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _authenticator = authenticator;
        _tokenStorage = tokenStorage;
    }

    public async Task HandleAsync(SignInCommand command)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);

        if (user is null)
            throw new InvalidCredentialException();

        if (!_passwordManager.Validate(command.Password, user.Password))
            throw new InvalidCredentialException();

        var jwt = _authenticator.CreateToken(user.Id);
        _tokenStorage.Set(jwt);
    }
}