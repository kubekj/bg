using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class ExerciseWorkoutRepository : IExerciseWorkoutRepository
{
    private readonly DbSet<ExerciseWorkout> _exerciseWorkouts;

    public ExerciseWorkoutRepository(BodyGuardDbContext context) => _exerciseWorkouts = context.ExerciseWorkouts;

    public async Task<IEnumerable<ExerciseWorkout>> GetAllAsync(Expression<Func<ExerciseWorkout, bool>> expression = default)
    {
        if (expression == default)
            return await _exerciseWorkouts.AsNoTracking().Include(ew => ew.Sets).ToListAsync();

        return await _exerciseWorkouts.AsNoTracking().Include(ew => ew.Sets).Where(expression).ToListAsync();
    }

    public async Task<ExerciseWorkout> GetByIdAsync(Guid exerciseId, Guid workoutId) 
        => await _exerciseWorkouts.FirstOrDefaultAsync(ew => ew.ExerciseId == exerciseId && ew.WorkoutId == workoutId);
    
    

    public async Task AddAsync(ExerciseWorkout exerciseWorkout) => await _exerciseWorkouts.AddAsync(exerciseWorkout);
    public async Task EditAsync(ExerciseWorkout exerciseWorkout)
    {
        _exerciseWorkouts.Update(exerciseWorkout);
        await Task.CompletedTask;
    }

    public async Task RemoveAsync(Guid workoutId, Guid exerciseId)
    {
        var exerciseWorkout = await _exerciseWorkouts.FindAsync(exerciseId,workoutId);
        if (exerciseWorkout != null) _exerciseWorkouts.Remove(exerciseWorkout);
    }
}