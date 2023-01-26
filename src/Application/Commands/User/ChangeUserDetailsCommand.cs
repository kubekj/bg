using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User;

public record ChangeUserDetailsCommand(
    string FirstName,
    string LastName,
    string Email,
    string Bio,
    string PreferredLanguage,
    double Weight,
    double Height,
    int CaloriesIntake) : ICommand; 