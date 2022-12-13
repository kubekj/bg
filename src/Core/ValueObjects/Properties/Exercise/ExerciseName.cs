using Core.Exceptions.ValueObjects.Exercise;
using Core.SeedWork;

namespace Core.ValueObjects.Properties.Exercise;

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
        => exerciseName.Value;

    public static implicit operator ExerciseName(string value)
        => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}