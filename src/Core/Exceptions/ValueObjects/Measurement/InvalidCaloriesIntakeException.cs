using Core.ValueObjects.Measurement;

namespace Core.Exceptions.ValueObjects.Measurement;

public class InvalidCaloriesIntakeException : CoreException
{
    public InvalidCaloriesIntakeException(int value) : base($"Max calories intake is {CaloriesIntake.MaxAmount} and You entered: {value}") => Value = value;

    public int Value { get; }
}