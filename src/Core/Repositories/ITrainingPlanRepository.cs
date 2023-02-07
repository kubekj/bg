using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface ITrainingPlanRepository
{
    public Task<IEnumerable<TrainingPlan>> GetAllAsync(Expression<Func<TrainingPlan, bool>>? expression = default);
    public Task<TrainingPlan?> GetByIdAsync(Guid trainingPlanId);
    public Task AddAsync(TrainingPlan trainingPlan);
    public Task UpdateAsync(TrainingPlan trainingPlan);
}