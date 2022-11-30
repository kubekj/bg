using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Application.Security;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Core.Shared;
using Core.ValueObjects.User;
using MediatR;

namespace Application.Commands.Handlers;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;

    public SignUpCommandHandler(IUserRepository userRepository, IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
    }

    public async Task<Unit> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var email = new Email(request.Email);
        var firstName = new FirstName(request.FirstName);
        var lastName = new LastName(request.LastName);
        var password = new Password(request.Password);
        var enumsHasParsed = Enum.TryParse(request.Role, out Role role);

        if (!enumsHasParsed)
            throw new InvalidUserRoleException();

        if (await _userRepository.GetByEmailAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        var securedPassword = _passwordManager.Secure(password);

        User user = role switch
        {
            Role.Athlete => new Athlete(userId, firstName, lastName, email, securedPassword, role, _clock.Current()),
            Role.Trainer => new Trainer(userId, firstName, lastName, email, securedPassword, role, _clock.Current()),
            _ => throw new ArgumentOutOfRangeException()
        };

        await _userRepository.AddAsync(user);

        return Unit.Value;
    }
}