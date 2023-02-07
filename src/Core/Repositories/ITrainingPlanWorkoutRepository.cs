using Core.Entities;

namespace Core.Repositories;

public interface ITrainingPlanWorkoutRepository
{
    public Task AddAsync(TrainingPlanWorkout trainingPlanWorkout);
    public Task RemoveAsync(TrainingPlanWorkout trainingPlanWorkout);
}