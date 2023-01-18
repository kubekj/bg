using Core.Entities;

namespace Core.Services.Exercise;

public class UserWorkoutService : IUserWorkoutService
{
    public Guid? CheckIfUserWorkoutAlreadyExists(IEnumerable<UserWorkout> userWorkouts, Workout workout) => 
        userWorkouts.FirstOrDefault(x => x.Workout.Name.Equals(workout.Name))?.WorkoutId;
}