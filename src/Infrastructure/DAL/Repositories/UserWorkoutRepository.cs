using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserWorkoutRepository : IUserWorkoutRepository
{
    private readonly DbSet<UserWorkout> _userWorkouts;

    public UserWorkoutRepository(BodyGuardDbContext context)
    {
        _userWorkouts = context.UserWorkouts;
    }

    public async Task<IEnumerable<UserWorkout>> GetAllAsync(Expression<Func<UserWorkout, bool>> expression = default)
    {
        if (expression == default)
            return await _userWorkouts
                .ToListAsync();

        return await _userWorkouts
            .Where(expression)
            .ToListAsync();
    }

    public async Task AddAsync(UserWorkout userWorkout) => await _userWorkouts.AddAsync(userWorkout);
    
    public async Task RemoveAsync(Guid userId, Guid workoutId)
    {
        var userWorkout = await _userWorkouts.FindAsync(userId, workoutId);
        if (userWorkout != null) _userWorkouts.Remove(userWorkout);
    }
}