using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface ITrainingPlanRepository
{
    public Task<IEnumerable<TrainingPlan>> GetAllAsync(Expression<Func<TrainingPlan, bool>>? expression = default);
    public Task<TrainingPlan?> GetByIdAsync();
    public Task AddAsync(TrainingPlan trainingPlan);
}