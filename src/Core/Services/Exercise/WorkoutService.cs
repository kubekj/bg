using Core.Entities;

namespace Core.Services.Exercise;

public class WorkoutService : IWorkoutService
{
    public Workout? CheckIfWorkoutAlreadyExists(IEnumerable<Workout> workouts,Workout workout) =>
        workouts.FirstOrDefault(w => w.Name.Equals(workout.Name)
                                     && w.Category.Equals(workout.Category)
                                     && Equals(w.ExerciseWorkouts.Select(x => x.Exercise),
                                         workout.ExerciseWorkouts.Select(x => x.Exercise)));

    public Workout? CheckIfWorkoutWithTheSameNameAlreadyExists(IEnumerable<Workout> workouts, Workout workout) => 
        workouts.FirstOrDefault(w => w.Name.Equals(workout.Name));
}