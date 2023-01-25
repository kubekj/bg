namespace Core.Services.TrainingPlan;

public interface ITrainingPlanService
{
    public Entities.TrainingPlan? CheckIfTrainingPlanExists(IEnumerable<Entities.TrainingPlan> trainingPlans, Entities.TrainingPlan trainingPlan);
}