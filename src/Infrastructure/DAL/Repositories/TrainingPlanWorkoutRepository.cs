using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class TrainingPlanWorkoutRepository : ITrainingPlanWorkoutRepository
{
    private readonly DbSet<TrainingPlanWorkout> _trainingPlanWorkouts;

    public TrainingPlanWorkoutRepository(BodyGuardDbContext context)
    {
        _trainingPlanWorkouts = context.TrainingPlanWorkouts;
    }

    public async Task AddAsync(TrainingPlanWorkout trainingPlanWorkout)
    {
        await _trainingPlanWorkouts.AddAsync(trainingPlanWorkout);
    }

    public async Task RemoveAsync(TrainingPlanWorkout trainingPlanWorkout)
    {
        _trainingPlanWorkouts.Remove(trainingPlanWorkout);
        await Task.CompletedTask;
    }
}