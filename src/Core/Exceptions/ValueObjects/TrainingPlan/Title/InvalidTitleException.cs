namespace Core.Exceptions.ValueObjects.TrainingPlan.Title;

public class InvalidTitleException : CoreException
{
    public InvalidTitleException() : base("Title cannot be empty !")
    {
    }
}