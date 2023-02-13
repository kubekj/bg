using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class UserExerciseRepository : IUserExerciseRepository
{
    private readonly DbSet<UserExercise> _userExercises;

    public UserExerciseRepository(BodyGuardDbContext context)
    {
        _userExercises = context.UserExercises;
    }

    public async Task<IEnumerable<UserExercise>> GetAllForUserAsync(Guid userId) => await _userExercises
        .Include(x => x.Exercise)
        .Where(x => x.UserId == userId).ToListAsync();
    
    public async Task<IEnumerable<UserExercise>> GetAllAsync(Expression<Func<UserExercise, bool>> expression = default)
    {
        if (expression == default)
            return await _userExercises.ToListAsync();

        return await _userExercises.Where(expression).ToListAsync();
    }

    public async Task<UserExercise> GetByIdAsync(Guid userId, Guid exerciseId) => await _userExercises
        .Include(x => x.Exercise)
        .FirstOrDefaultAsync(x => x.UserId == userId && x.ExerciseId == exerciseId );

    public async Task AddAsync(UserExercise userExercise) => await _userExercises.AddAsync(userExercise);

    public async Task RemoveAsync(Guid userId, Guid exerciseId)
    {
        var userExercise = await _userExercises.FindAsync(userId,exerciseId);
        if (userExercise != null) _userExercises.Remove(userExercise);
    }
}