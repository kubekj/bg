using Core.Exceptions.ValueObjects.TrainingPlan.Title;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public sealed class Title : ValueObject
{
    public const int MaxLength = 50;

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            throw new InvalidTitleException();

        if (value.Length > MaxLength)
            throw new TitleOutOfRangeException(value, MaxLength);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(Title title)
    {
        return title.Value;
    }

    public static implicit operator Title(string value)
    {
        return new(value);
    }

    public override string ToString()
    {
        return Value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}