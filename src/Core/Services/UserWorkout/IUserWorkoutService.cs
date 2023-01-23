namespace Core.Services.UserWorkout;

public interface IUserWorkoutService
{
    public Entities.UserWorkout? CheckIfUserWorkoutAlreadyExists(IEnumerable<Entities.UserWorkout> userWorkouts, Entities.Workout existingWorkout);
}