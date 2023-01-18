using Core.Exceptions.ValueObjects.Exercise;
using Core.SeedWork;

namespace Core.ValueObjects.Exercise;

public class ExerciseName : ValueObject
{
    public const int MaxLenght = 50;

    public ExerciseName(string value)
    {
        if (!value.All(char.IsLetter))
            throw new InvalidExerciseNameException(value);

        if (value.Length > MaxLenght)
            throw new InvalidExerciseNameException(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(ExerciseName exerciseName)
    {
        return exerciseName.Value;
    }

    public static implicit operator ExerciseName(string value)
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