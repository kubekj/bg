using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.Properties.Workout;

namespace Core.Entities;

public class Workout : Entity
{
    public Workout(Guid id, WorkoutName name, Category category, IEnumerable<Exercise> exercises) : base(id)
    {
        Name = name;
        Category = category;
        Exercises = exercises;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
    }

    public WorkoutName Name { get; private set; }
    public Category Category { get; private set; }
    public IEnumerable<TrainingPlanWorkout> TrainingPlanWorkouts { get; private set; }
    public IEnumerable<UserWorkout> UserWorkouts { get; private set; }
    public IEnumerable<Exercise> Exercises { get; private set; }
}