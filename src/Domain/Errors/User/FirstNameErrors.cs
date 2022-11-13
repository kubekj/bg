using FluentResults;

namespace Domain.Errors.User;

public static class FirstNameErrors
{
    public static Error NullOrWhiteSpace(string firstName) => new($"{firstName} is null or contains a whitespace");
    public static Error IsTooLong(string firstName, int maxLength) => new($"{firstName} is too long, name should contain max {maxLength} literals");
}