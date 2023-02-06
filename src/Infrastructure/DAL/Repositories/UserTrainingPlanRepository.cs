using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserTrainingPlanRepository : IUserTrainingPlanRepository
{
    private DbSet<UserTrainingPlan> _userTrainingPlans;

    public UserTrainingPlanRepository(BodyGuardDbContext context)
    {
        _userTrainingPlans = context.UserTrainingPlans;
    }
    
    public async Task<IEnumerable<UserTrainingPlan>> GetAllAsync(Expression<Func<UserTrainingPlan, bool>> expression = default)
    {
        if (expression != default)
            return await _userTrainingPlans
                .Where(expression)
                .Include(utp => utp.TrainingPlan)
                .ThenInclude(x => x.TrainingPlanWorkouts)
                .ThenInclude(tpw => tpw.Workout)
                .ThenInclude(w => w.ExerciseWorkouts)
                .ThenInclude(ew => ew.Exercise)
                .ToListAsync();

        return await _userTrainingPlans
            .Include(utp => utp.TrainingPlan)
            .ThenInclude(x => x.TrainingPlanWorkouts)
            .ThenInclude(tpw => tpw.Workout)
            .ThenInclude(w => w.ExerciseWorkouts)
            .ThenInclude(ew => ew.Exercise)
            .ToListAsync();
    }

    public async Task AddAsync(UserTrainingPlan userTrainingPlan) => await _userTrainingPlans.AddAsync(userTrainingPlan);
}