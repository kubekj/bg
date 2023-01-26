using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserWorkoutSessionRepository : IUserWorkoutSessionRepository
{
    private readonly DbSet<UserWorkoutSession> _workoutSessions;

    public UserWorkoutSessionRepository(BodyGuardDbContext context) => _workoutSessions = context.UserWorkoutSessions;

    public async Task AddAsync(UserWorkoutSession userWorkoutSession) => await _workoutSessions.AddAsync(userWorkoutSession);
}