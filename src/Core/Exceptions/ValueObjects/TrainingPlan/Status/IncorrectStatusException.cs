namespace Core.Exceptions.ValueObjects.TrainingPlan.Status;

internal class IncorrectStatusException : CoreException
{
    public string Status { get; }
    public IncorrectStatusException(string status) : base($"Training status: {status} is not supported") 
        => Status = status;
}