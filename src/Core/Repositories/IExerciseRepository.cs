using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(Guid id);
    Task<IEnumerable<Exercise>> GetAllAsync(Expression<Func<Exercise, bool>>? expression = default);
    Task AddAsync(Exercise exercise);
    Task RemoveAsync(Guid id);
    Task EditAsync(Exercise exercise);
}