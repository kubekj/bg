using Core.Exceptions.Common;

namespace Core.Exceptions.ValueObjects.TrainingPlan.Description;

public class DescriptionOutOfRangeException : StringPropertyOutOfRangeException
{
    public DescriptionOutOfRangeException(string value, int maxLenght) : base(value, maxLenght,
        $"Description: {value} is too long, max lenght is: {maxLenght}")
    {
    }
}