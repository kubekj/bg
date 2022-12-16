using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Application.Security;
using Core.Repositories;
using Core.Shared;
using Core.ValueObjects.User;

namespace Application.Commands.User.Handlers;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IClock _clock;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;

    public SignUpCommandHandler(IUserRepository userRepository, IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
    }

    public async Task HandleAsync(SignUpCommand command)
    {
        var userId = command.UserId;
        var email = new Email(command.Email);
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var password = new Password(command.Password);

        if (await _userRepository.GetByEmailAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        var securedPassword = _passwordManager.Secure(password);

        var user = new Core.Entities.User(userId, firstName, lastName, email, securedPassword, _clock.Current());

        await _userRepository.AddAsync(user);
    }
}