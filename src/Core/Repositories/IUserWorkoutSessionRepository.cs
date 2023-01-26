using Core.Entities;

namespace Core.Repositories;

public interface IUserWorkoutSessionRepository
{
    public Task AddAsync(UserWorkoutSession userWorkoutSession);
}