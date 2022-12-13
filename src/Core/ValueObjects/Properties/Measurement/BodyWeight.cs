using Core.SeedWork;

namespace Core.ValueObjects.Properties.Measurement;

public class BodyWeight : ValueObject
{
    public BodyWeight(double value)
    {
        Value = value;
    }

    public double Value { get; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}