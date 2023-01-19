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
                .ToListAsync();

        return await _workouts
            .Include(w => w.ExerciseWorkouts)
            .ThenInclude(we => we.Exercise)
            .Where(w => w.UserWorkouts.Any(uw => uw.UserId == userId))
            .ToListAsync();
    }

    public async Task<Workout> GetByIdAsync(Guid userId, Guid workoutId)
    {
        return await _workouts
            .Include(w => w.ExerciseWorkouts)
            .ThenInclude(we => we.Exercise)
            .FirstOrDefaultAsync(w => w.UserWorkouts.Any(uw => uw.UserId == userId) && w.Id == workoutId);
    }

    public async Task AddAsync(Workout workout) => await _workouts.AddAsync(workout);

    public Task RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(Workout workout)
    {
        throw new NotImplementedException();
    }
}