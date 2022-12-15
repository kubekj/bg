namespace Core.Exceptions.ValueObjects.TrainingPlan.Status;

internal class IncorrectStatusException : CoreException
{
    public IncorrectStatusException(string status) : base($"Training status: {status} is not supported")
    {
        Status = status;
    }

    public string Status { get; }
}