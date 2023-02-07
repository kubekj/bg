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
                .Include(tp => tp.Ratings)
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
            .Include(tp => tp.Ratings)
            .ToListAsync();
    }

    public Task<TrainingPlan> GetByIdAsync(Guid trainingPlanId) =>
        _trainingPlans      
            .Include(tp => tp.Author)
            .Include(tp => tp.TrainingPlanWorkouts)
            .ThenInclude(tpw => tpw.Workout)
            .ThenInclude(w => w.ExerciseWorkouts)
            .ThenInclude(ew => ew.Exercise)
            .ThenInclude(e => e.ExerciseWorkouts)
            .ThenInclude(ew => ew.Sets)
            .Include(tp => tp.Ratings)
            .FirstOrDefaultAsync(tp => tp.Id == trainingPlanId);

    public async Task AddAsync(TrainingPlan trainingPlan) => await _trainingPlans.AddAsync(trainingPlan);
    public async Task UpdateAsync(TrainingPlan trainingPlan)
    {
        _trainingPlans.Update(trainingPlan);
        await Task.CompletedTask;
    }
}