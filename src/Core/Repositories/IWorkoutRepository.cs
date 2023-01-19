using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IWorkoutRepository
{
    Task<IEnumerable<Workout>> GetAllAsync(Guid userId = default);
    Task<Workout> GetByIdAsync(Guid userId, Guid workoutId);
    Task AddAsync(Workout workout);
    Task RemoveAsync(Guid id);
    Task EditAsync(Workout workout);
}