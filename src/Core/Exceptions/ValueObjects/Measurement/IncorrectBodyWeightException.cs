using Core.ValueObjects.Properties.Measurement;

namespace Core.Exceptions.ValueObjects.Measurement;

public class IncorrectBodyWeightException : CoreException
{
    public IncorrectBodyWeightException(double value)
        : base($"Provided body weight: {value} extends max value which is {BodyWeight.MaxWeight}")
    {
        Value = value;
    }

    public double Value { get; }
}