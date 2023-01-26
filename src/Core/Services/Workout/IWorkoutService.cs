namespace Core.Services.Workout;

public interface IWorkoutService
{
    public Entities.Workout? CheckIfWorkoutAlreadyExists(IEnumerable<Entities.Workout> workouts,Entities.Workout workout);
}