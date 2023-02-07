using Core.Entities;

namespace Core.Repositories;

public interface IRatingRepository
{
    public Task<Rating?> GetRatingForPlan(Guid userId, Guid trainingPlanId);
    public Task<IEnumerable<Rating>> GetAllRatingsForPlan();
    public Task RatePlan(Rating rating);
}