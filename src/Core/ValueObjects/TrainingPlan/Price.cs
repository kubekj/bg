using Core.Exceptions.ValueObjects.TrainingPlan.Price;
using Core.SeedWork;

namespace Core.ValueObjects.TrainingPlan;

public record Price : ValueObject
{
    private const decimal MaximumPrice = 1000;
    
    public Price(decimal value)
    {
        if (value > MaximumPrice)
            throw new InvalidPriceException(value,MaximumPrice);

        Value = value;
    }
    public decimal Value { get; }
    
    public static implicit operator decimal(Price title)
        => title.Value;

    public static implicit operator Price(decimal value)
        => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}