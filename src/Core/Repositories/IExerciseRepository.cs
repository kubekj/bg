using Core.Entities;

namespace Core.Repositories;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(Guid id);
    Task<IEnumerable<Exercise>> GetAllAsync();
    Task AddAsync(Exercise exercise);
    Task Remove(Guid id);
    Task Edit(Exercise exercise);
}