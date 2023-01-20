using Core.Entities;

namespace Core.Services.Exercise;

public interface IUserWorkoutService
{
    public Guid? CheckIfUserWorkoutAlreadyExists(IEnumerable<UserWorkout> userWorkouts, Guid existingWorkout);
}