using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IUserTrainingPlanRepository
{
    public Task<IEnumerable<UserTrainingPlan>> GetAllAsync(Expression<Func<UserTrainingPlan, bool>>? expression = default);
    public Task<UserTrainingPlan?> GetByIdAsync(Guid userId, Guid trainingPlanId);
    public Task AddAsync(UserTrainingPlan userTrainingPlan);
}