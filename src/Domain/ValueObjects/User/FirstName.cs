using Domain.Errors.User;
using Domain.Primitives;
using FluentResults;

namespace Domain.ValueObjects.User;

public sealed class FirstName : ValueObject
{
    private const int MaxLength = 50;
    
    private FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Result.Fail<FirstName>(FirstNameErrors.NullOrWhiteSpace(firstName));

        if (firstName.Length > MaxLength)
            return Result.Fail<FirstName>(FirstNameErrors.IsTooLong(firstName,MaxLength));

        return new FirstName(firstName);
    }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}