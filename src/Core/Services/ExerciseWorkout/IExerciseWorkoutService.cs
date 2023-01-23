using Core.Entities;

namespace Core.Services.ExerciseWorkout;

public interface IExerciseWorkoutService
{
    public Task HandleExerciseWithSetsCreation(Guid workoutId,IDictionary<Guid,IEnumerable<Set>> exerciseWithSets);
    public Task HandleExerciseWithSetsEdition(Guid workoutId,IDictionary<Guid,IEnumerable<Set>> exerciseWithSets);
    public Task<IEnumerable<Guid>> GetExercisesForWorkoutAsync(Guid workoutId);
    public Task<IDictionary<Guid,IEnumerable<Set>>> GetSetsForWorkoutAsync(Guid workoutId);
}