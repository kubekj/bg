using Core.Exceptions.Utils;

namespace Core.Exceptions.ValueObjects.TrainingPlan.Title;

public class TitleOutOfRangeException : StringPropertyOutOfRangeException
{
    public TitleOutOfRangeException(string value, int maxLenght) : base(value, maxLenght,
        $"Title: {value} is too long, max lenght is: {maxLenght}")
    {
    }
}