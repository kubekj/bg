namespace Core.Exceptions.ValueObjects.TrainingPlan.Price;

public class InvalidPriceException : CoreException
{
    public InvalidPriceException(decimal currentPrice, decimal maximumPrice) : base(
        $"Price:{currentPrice} is too high, maximum price is equal to {maximumPrice}")
    {
        CurrentPrice = currentPrice;
        MaximumPrice = maximumPrice;
    }

    public decimal MaximumPrice { get; }

    public decimal CurrentPrice { get; }
}