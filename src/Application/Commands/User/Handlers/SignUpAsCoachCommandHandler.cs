using Application.Abstractions.Messaging.Command;
using Core.Repositories;
using Core.ValueObjects.User;

namespace Application.Commands.User.Handlers;

public class SignUpAsCoachCommandHandler : ICommandHandler<SignUpAsCoachCommand>
{
    private readonly IUserRepository _userRepository;

    public SignUpAsCoachCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task HandleAsync(SignUpAsCoachCommand command)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);

        if (user is null || user.Role.Equals(Role.Trainer()))
            return;

        user.RegisterAsTrainer();
        await _userRepository.EditUserDetails(user);
    }
}