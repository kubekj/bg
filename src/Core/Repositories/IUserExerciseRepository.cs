using Core.Entities;

namespace Core.Repositories;

public interface IUserExerciseRepository
{
    public Task<IEnumerable<UserExercise>> GetAllAsync();
}