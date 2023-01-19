using Core.Entities;

namespace Core.Services.Exercise;

public class WorkoutService : IWorkoutService
{
    public Guid? CheckIfWorkoutAlreadyExists(IEnumerable<Workout> workouts,Workout workout)
    {
        return workouts.FirstOrDefault(w => w.Name.Equals(workout.Name)
                                 || w.Category.Equals(workout.Category)
                                 || Equals(w.ExerciseWorkouts.Select(x => x.Exercise),
                                     workout.ExerciseWorkouts.Select(x => x.Exercise)))?.Id;
    }
}