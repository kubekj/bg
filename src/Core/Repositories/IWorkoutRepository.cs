using Core.Entities;

namespace Core.Repositories;

public interface IWorkoutRepository
{
    Task<IEnumerable<Workout>> GetAllAsync(Guid userId = default);
    Task<Workout> GetByIdAsync(Guid workoutId,Guid userId = default);
    Task AddAsync(Workout workout);
    Task RemoveAsync(Guid id);
    Task EditAsync(Workout workout);
}