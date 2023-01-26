namespace Core.Services.UserWorkout;

public class UserWorkoutService : IUserWorkoutService
{
    public Entities.UserWorkout? CheckIfUserWorkoutAlreadyExists(IEnumerable<Entities.UserWorkout> userWorkouts, Entities.Workout existingWorkout) => 
        userWorkouts.FirstOrDefault(x => x.WorkoutId == existingWorkout.Id || x.Workout.Name.Equals(existingWorkout.Name));
    
}