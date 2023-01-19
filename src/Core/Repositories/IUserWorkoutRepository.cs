using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IUserWorkoutRepository
{
    Task<IEnumerable<UserWorkout>> GetAllAsync(Expression<Func<UserWorkout, bool>>? expression = default);
    Task<UserWorkout?> GetByIdAsync(Guid userId, Guid workoutId);
    Task AddAsync(UserWorkout workout);
    Task RemoveAsync(Guid userId, Guid workoutId);
}