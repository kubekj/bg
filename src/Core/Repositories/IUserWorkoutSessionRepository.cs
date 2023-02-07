using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IUserWorkoutSessionRepository
{
    public Task<IEnumerable<UserWorkoutSession>> GetAllAsync(Expression<Func<UserWorkoutSession, bool>>? expression = default);
    public Task AddAsync(UserWorkoutSession userWorkoutSession);
    public Task EditAsync(UserWorkoutSession userWorkoutSession);
}