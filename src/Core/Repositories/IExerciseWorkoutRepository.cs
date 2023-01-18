using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IExerciseWorkoutRepository
{
    Task<IEnumerable<ExerciseWorkout>> GetAllAsync(Expression<Func<ExerciseWorkout, bool>>? expression = default);
    Task AddAsync(ExerciseWorkout exerciseWorkout);
}