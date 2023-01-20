using Core.Entities;

namespace Core.Services.Exercise;

public interface IWorkoutService
{
    public Workout? CheckIfWorkoutAlreadyExists(IEnumerable<Workout> workouts,Workout workout);
    public Workout? CheckIfWorkoutWithTheSameNameAlreadyExists(IEnumerable<Workout> workouts,Workout workout);
}