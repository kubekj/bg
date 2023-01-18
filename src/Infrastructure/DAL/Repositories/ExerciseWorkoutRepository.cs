using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class ExerciseWorkoutRepository : IExerciseWorkoutRepository
{
    private readonly DbSet<ExerciseWorkout> _exerciseWorkouts;

    public ExerciseWorkoutRepository(BodyGuardDbContext context) => _exerciseWorkouts = context.ExerciseWorkouts;

    public Task<IEnumerable<ExerciseWorkout>> GetAllAsync(Expression<Func<ExerciseWorkout, bool>> expression = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ExerciseWorkout exerciseWorkout) => await _exerciseWorkouts.AddAsync(exerciseWorkout);
}