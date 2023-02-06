using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class GoalRepository : IGoalRepository
{
    private readonly DbSet<Goal> _goals;

    public GoalRepository(BodyGuardDbContext context) => _goals = context.Goals;

    public async Task<int> GetByMonth(Guid userId)
    {
        var goal = await _goals.FirstOrDefaultAsync(x => x.Month == DateTime.Now.Month && x.UserId == userId);
        return goal.Value;
    }

    public async Task AddAsync(Goal goal) => await _goals.AddAsync(goal);
    public async Task EditAsync(Goal goal)
    {
        _goals.Update(goal);
        await Task.CompletedTask;
    }
}