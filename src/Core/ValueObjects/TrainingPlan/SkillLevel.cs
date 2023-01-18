using Core.Exceptions.ValueObjects.TrainingPlan.SkillLevel;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public class SkillLevel : ValueObject
{
    public const string Beginner = nameof(Beginner);
    public const string Intermediate = nameof(Intermediate);
    public const string Advanced = nameof(Advanced);

    public SkillLevel(string value)
    {
        if (value is not (Beginner or Intermediate or Advanced))
            throw new IncorrectSkillLevelException(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(SkillLevel skillLevel)
    {
        return skillLevel.Value;
    }

    public static implicit operator SkillLevel(string value)
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