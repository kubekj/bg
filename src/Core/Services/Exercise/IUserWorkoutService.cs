using Core.Entities;

namespace Core.Services.Exercise;

public interface IUserWorkoutService
{
    public UserWorkout? CheckIfUserWorkoutAlreadyExists(IEnumerable<UserWorkout> userWorkouts, Workout existingWorkout);
}