using Core.ValueObjects.Properties.Measurement;

namespace Core.Exceptions.ValueObjects.Measurement;

public class InvalidBodyHeightException : CoreException
{
    public InvalidBodyHeightException(double value)
        : base($"Provided body height: {value} extends max value which is {BodyHeight.MaxHeight}")
    {
        Value = value;
    }

    public double Value { get; }
}