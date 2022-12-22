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

    public async Task<IEnumerable<UserExercise>> GetAllAsync()
    {
        return await _userExercises.ToListAsync();
    }

    public async Task AddAsync(UserExercise userExercise)
    {
        await _userExercises.AddAsync(userExercise);
    }
}