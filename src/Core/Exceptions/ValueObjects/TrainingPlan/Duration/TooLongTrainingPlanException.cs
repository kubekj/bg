namespace Core.Exceptions.ValueObjects.TrainingPlan.Duration;

public class TooLongTrainingPlanException : CoreException
{
    public TooLongTrainingPlanException(double currentWeekCount, double maxWeekCount) : base($"Duration:{currentWeekCount} is too high, maximum duration is equal to {maxWeekCount}")
    {
        CurrentWeekCount = currentWeekCount;
        MaxWeekCount = maxWeekCount;
    }

    public double MaxWeekCount { get; private set; }

    public double CurrentWeekCount { get; private set; }
}