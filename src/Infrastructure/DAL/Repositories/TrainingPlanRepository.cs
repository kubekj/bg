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
            return await _trainingPlans
                .Include(tp => tp.Author)
                .Include(tp => tp.TrainingPlanWorkouts)
                .ThenInclude(tpw => tpw.Workout)
                .ThenInclude(w => w.ExerciseWorkouts)
                .ThenInclude(ew => ew.Exercise)
                .ThenInclude(e => e.ExerciseWorkouts)
                .ThenInclude(ew => ew.Sets)
                .Where(expression)
                .ToListAsync();

        return await _trainingPlans               
            .Include(tp => tp.Author)
            .Include(tp => tp.TrainingPlanWorkouts)
            .ThenInclude(tpw => tpw.Workout)
            .ThenInclude(w => w.ExerciseWorkouts)
            .ThenInclude(ew => ew.Exercise)
            .ThenInclude(e => e.ExerciseWorkouts)
            .ThenInclude(ew => ew.Sets)
            .ToListAsync();
    }

    public Task<TrainingPlan> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(TrainingPlan trainingPlan) => await _trainingPlans.AddAsync(trainingPlan);
}