using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class SetRepository : ISetRepository
{
    private readonly DbSet<Set> _sets;

    public SetRepository(BodyGuardDbContext context) => _sets = context.Sets;

    public async Task<IEnumerable<Set>> GetAllAsync(Expression<Func<Set, bool>> expression = default)
    {
        if (expression != default)
            return await _sets
                .Where(expression)
                .ToListAsync();

        return await _sets
            .ToListAsync();
    }

    public async Task EditAsync(Set set)
    {
        _sets.Update(set);
        await Task.CompletedTask;
    }
}