namespace Core.Exceptions.ValueObjects.TrainingPlan.Description;

public class InvalidDescriptionException : CoreException
{
    public InvalidDescriptionException() : base("Description should contain value !")
    {
    }
}