using Core.SeedWork;

namespace Core.ValueObjects.Properties.Measurement;

public class BodyHeight : ValueObject
{
    public BodyHeight(double value)
    {
        Value = value;
    }

    public double Value { get; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}