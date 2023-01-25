using Core.Exceptions;
using Core.ValueObjects.TrainingPlan;

namespace Application.Exceptions;

public class TrainingPlanAlreadyExistsException : CoreException
{
    public TrainingPlanAlreadyExistsException(Title trainingPlanTitle) : base($"Training plan with a title: {trainingPlanTitle} already exists in your list")
    {
    }
}