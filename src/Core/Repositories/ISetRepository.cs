using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface ISetRepository
{
    public Task<IEnumerable<Set>> GetAllAsync(Expression<Func<Set, bool>>? expression = default);

    public Task RemoveAsync(Set set);
    public Task AddAsync(Set set);
}