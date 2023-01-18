namespace Core.Exceptions.ValueObjects.Set;

public class InvalidWeightException : CoreException
{
    public InvalidWeightException(double value, int maxWeight)
        : base($"Weight cannot be bigger than {maxWeight} but is {value}")
    {
        Value = value;
    }

    public double Value { get; set; }
}