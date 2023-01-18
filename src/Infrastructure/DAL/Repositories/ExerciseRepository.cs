using System.Linq.Expressions;
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
    
    public async Task<Exercise> GetByIdAsync(Guid id) => await _exercises.FindAsync(id);

    public async Task<IEnumerable<Exercise>> GetAllAsync(Expression<Func<Exercise, bool>> expression = default) => await _exercises.ToListAsync();

    public async Task AddAsync(Exercise exercise) => await _exercises.AddAsync(exercise);

    public async Task RemoveAsync(Guid id)
    {
        var exercise = await _exercises.FindAsync(id);
        if (exercise != null) _exercises.Remove(exercise);
    }

    public Task EditAsync(Exercise exercise)
    {
        _exercises.Update(exercise);
        return Task.CompletedTask;
    }
}