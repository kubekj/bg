namespace Core.Exceptions.ValueObjects.Exercise;

public class InvalidExerciseNameException : CoreException
{
    public InvalidExerciseNameException(string value) : base($"Exercise cannot have name like this : {value}") => Value = value;

    public string Value { get; set; }
}