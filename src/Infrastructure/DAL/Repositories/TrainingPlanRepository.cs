using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class TrainingPlanRepository : ITrainingPlanRepository
{
    private readonly DbSet<TrainingPlan> _trainingPlans;

    public TrainingPlanRepository(BodyGuardDbContext context) => _trainingPlans = context.TrainingPlans;
    
    public async Task<IEnumerable<TrainingPlan>> GetAllAsync(Expression<Func<TrainingPlan, bool>> expression = default)
    {
        if (expression != default)
            return await _trainingPlans.Where(expression).ToListAsync();

        return await _trainingPlans.ToListAsync();
    }

    public Task<TrainingPlan> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(TrainingPlan trainingPlan) => await _trainingPlans.AddAsync(trainingPlan);
}