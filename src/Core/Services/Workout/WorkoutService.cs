namespace Core.Services.Workout;

public class WorkoutService : IWorkoutService
{
    public Entities.Workout? CheckIfWorkoutAlreadyExists(IEnumerable<Entities.Workout> workouts,Entities.Workout workout) =>
        workouts.FirstOrDefault(w => w.Name.Equals(workout.Name)
                                     && w.Category.Equals(workout.Category)
                                     && Equals(w.ExerciseWorkouts.Select(x => x.Exercise),
                                         workout.ExerciseWorkouts.Select(x => x.Exercise)) 
                                     || w.Name.Equals(workout.Name));

}