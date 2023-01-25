using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;

namespace Infrastructure.DAL.Repositories;

public class UserTrainingPlanRepository : IUserTrainingPlanRepository
{
    public Task<IEnumerable<UserTrainingPlan>> GetAllAsync(Expression<Func<UserTrainingPlan, bool>> expression = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UserTrainingPlan userTrainingPlan)
    {
        throw new NotImplementedException();
    }
}