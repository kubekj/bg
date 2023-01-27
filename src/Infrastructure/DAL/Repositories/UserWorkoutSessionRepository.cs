using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserWorkoutSessionRepository : IUserWorkoutSessionRepository
{
    private readonly DbSet<UserWorkoutSession> _workoutSessions;

    public UserWorkoutSessionRepository(BodyGuardDbContext context) => _workoutSessions = context.UserWorkoutSessions;

    public async Task<IEnumerable<UserWorkoutSession>> GetAllAsync(Expression<Func<UserWorkoutSession, bool>> expression = default)
    {
        if (expression != default)
            return await _workoutSessions
                .Include(uws => uws.UserWorkout)
                .ThenInclude(uw => uw.Workout)
                .Where(expression)
                .ToListAsync();

        return await _workoutSessions
            .Include(uws => uws.UserWorkout)
            .ThenInclude(uw => uw.Workout)
            .ToListAsync();
    }

    public async Task AddAsync(UserWorkoutSession userWorkoutSession) => await _workoutSessions.AddAsync(userWorkoutSession);
}