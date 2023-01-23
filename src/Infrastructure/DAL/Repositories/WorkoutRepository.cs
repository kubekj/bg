using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class WorkoutRepository : IWorkoutRepository
{
    private readonly DbSet<Workout> _workouts;

    public WorkoutRepository(BodyGuardDbContext context) => _workouts = context.Workouts;

    public async Task<IEnumerable<Workout>> GetAllAsync(Guid userId = default)
    {
        if (userId == default)
            return await _workouts
                .Include(w => w.ExerciseWorkouts)
                .ThenInclude(we => we.Exercise)
                .ThenInclude(w => w.ExerciseWorkouts)
                .ThenInclude(s => s.Sets)
                .ToListAsync();

        return await _workouts
            .Include(w => w.ExerciseWorkouts)
            .ThenInclude(we => we.Exercise)
            .ThenInclude(w => w.ExerciseWorkouts)
            .ThenInclude(s => s.Sets)
            .Where(w => w.UserWorkouts.Any(uw => uw.UserId == userId))
            .ToListAsync();
    }

    public async Task<Workout> GetByIdAsync(Guid workoutId,Guid userId = default)
    {
        if (userId == default)
            return await _workouts
                .Include(w => w.ExerciseWorkouts)
                .ThenInclude(we => we.Exercise)
                .ThenInclude(w => w.ExerciseWorkouts)
                .ThenInclude(s => s.Sets)
                .FirstOrDefaultAsync(w => w.Id == workoutId);
        
        return await _workouts
            .Include(w => w.ExerciseWorkouts)
            .ThenInclude(we => we.Exercise)
            .ThenInclude(w => w.ExerciseWorkouts)
            .ThenInclude(s => s.Sets)
            .FirstOrDefaultAsync(w => w.UserWorkouts.Any(uw => uw.UserId == userId) && w.Id == workoutId);
    }

    public async Task AddAsync(Workout workout) => await _workouts.AddAsync(workout);

    public async Task RemoveAsync(Guid id)
    {
        var workout = await _workouts.FindAsync(id);
        if (workout != null) _workouts.Remove(workout);
    }

    public async Task EditAsync(Workout workout)
    {
        _workouts.Update(workout);
        await Task.CompletedTask;
    }
}