using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class RatingRepository : IRatingRepository
{
    private readonly DbSet<Rating> _ratings;

    public RatingRepository(BodyGuardDbContext bodyGuardDbContext)
    {
        _ratings = bodyGuardDbContext.Ratings;
    }

    public Task<Rating> GetRatingForPlan()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Rating>> GetAllRatingsForPlan()
    {
        throw new NotImplementedException();
    }

    public async Task RatePlan(Rating rating) => await _ratings.AddAsync(rating);
}