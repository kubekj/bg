using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IExerciseWorkoutRepository
{
    Task<IEnumerable<ExerciseWorkout>> GetAllAsync(Expression<Func<ExerciseWorkout, bool>>? expression = default);
    Task<ExerciseWorkout?> GetByIdAsync(Guid exerciseId, Guid workoutId);
    Task AddAsync(ExerciseWorkout exerciseWorkout);
    Task EditAsync(ExerciseWorkout exerciseWorkout);
    Task RemoveAsync(Guid exerciseId, Guid workoutId);
}