namespace Core.Services.TrainingPlan;

public class TrainingPlanService : ITrainingPlanService
{
    public Entities.TrainingPlan? CheckIfTrainingPlanExists(IEnumerable<Entities.TrainingPlan> trainingPlans, Entities.TrainingPlan trainingPlan)
    {
        return trainingPlans.FirstOrDefault(tp =>
            tp.Title.Equals(trainingPlan.Title) && tp.AuthorId == trainingPlan.AuthorId);
    }
}