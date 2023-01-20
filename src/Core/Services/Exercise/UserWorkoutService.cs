using Core.Entities;

namespace Core.Services.Exercise;

public class UserWorkoutService : IUserWorkoutService
{
    public UserWorkout? CheckIfUserWorkoutAlreadyExists(IEnumerable<UserWorkout> userWorkouts, Workout existingWorkout) => 
        userWorkouts.FirstOrDefault(x => x.WorkoutId == existingWorkout.Id || x.Workout.Name.Equals(existingWorkout.Name));
    
}