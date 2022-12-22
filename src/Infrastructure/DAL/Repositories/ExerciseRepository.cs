using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class ExerciseRepository : IExerciseRepository
{
    private readonly BodyGuardDbContext _context;
    private readonly DbSet<Exercise> _exercises;

    public ExerciseRepository(BodyGuardDbContext context)
    {
        _exercises = context.Exercises;
        _context = context;
    }


    public Task<Exercise> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync()
    {
        return await _exercises.ToListAsync();
    }

    public async Task AddAsync(Exercise exercise)
    {
        await _exercises.AddAsync(exercise);
    }

    public Task Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Edit(Exercise exercise)
    {
        throw new NotImplementedException();
    }
}