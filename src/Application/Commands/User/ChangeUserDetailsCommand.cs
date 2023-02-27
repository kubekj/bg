using System;
using Application.Abstractions.Messaging.Command;

namespace Application.Commands.User;

public record ChangeUserDetailsCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    string Bio,
    string PreferredLanguage,
    double Weight,
    double WeightGoal,
    double Height,
    int CaloriesIntake,
    int CaloriesIntakeGoal) : ICommand; 