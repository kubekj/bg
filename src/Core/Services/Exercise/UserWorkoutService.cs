using Core.Entities;

namespace Core.Services.Exercise;

public class UserWorkoutService : IUserWorkoutService
{
    public Guid? CheckIfUserWorkoutAlreadyExists(IEnumerable<UserWorkout> userWorkouts, Guid existingWorkout) => 
        userWorkouts.FirstOrDefault(x => x.WorkoutId == existingWorkout)?.WorkoutId;
}