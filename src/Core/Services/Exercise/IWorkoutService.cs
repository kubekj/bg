using Core.Entities;

namespace Core.Services.Exercise;

public interface IWorkoutService
{
    public Guid? CheckIfWorkoutAlreadyExists(IEnumerable<Workout> workouts,Workout workout);
}