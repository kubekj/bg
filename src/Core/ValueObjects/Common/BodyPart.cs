using Core.Exceptions.Shared;
using Core.SeedWork;

namespace Core.ValueObjects.Common;

public class BodyPart : ValueObject
{
    public const string Legs = nameof(Legs);
    public const string Arms = nameof(Arms);
    public const string Chest = nameof(Chest);
    public const string Shoulders = nameof(Shoulders);
    public const string Core = nameof(Core);
    
    public BodyPart(string value)
    {
        if (value is not (Legs or Arms or Chest or Shoulders or Core))
            throw new IncorrectBodyPartException(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(BodyPart bodyPart) => bodyPart.Value;

    public static implicit operator BodyPart(string value) => new(value);

    public override string ToString() => Value;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}