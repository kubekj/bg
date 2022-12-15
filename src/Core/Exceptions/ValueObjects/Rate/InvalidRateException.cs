namespace Core.Exceptions.ValueObjects.Rate;

public class InvalidRateException : CoreException
{
    public InvalidRateException(int rate, int minRange, int maxRange)
        : base($"Rate should be in range from {minRange} to {maxRange} but is {rate}")
    {
        Rate = rate;
    }

    public int Rate { get; }
}