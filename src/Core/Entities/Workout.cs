using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.Workout;

namespace Core.Entities;

public class Workout : Entity
{
    public Workout(Guid id, WorkoutName name, Category category) : base(id)
    {
        Name = name;
        Category = category;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
        UserWorkouts = new HashSet<UserWorkout>();
        ExerciseWorkouts = new HashSet<ExerciseWorkout>();
        UserWorkoutSessions = new HashSet<UserWorkoutSession>();
    }
    
    public Workout(Guid id, WorkoutName name, Category category, IEnumerable<ExerciseWorkout> exerciseWorkouts) : base(id)
    {
        Name = name;
        Category = category;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
        UserWorkouts = new HashSet<UserWorkout>();
        ExerciseWorkouts = exerciseWorkouts;
        UserWorkoutSessions = new HashSet<UserWorkoutSession>();
    }

    public Workout CreateCopyForUser(string? name = default, string? category = default) => 
        new(Guid.NewGuid(), name ?? Name, category ?? Category);

    public WorkoutName Name { get; }
    public Category Category { get; }
    public IEnumerable<TrainingPlanWorkout> TrainingPlanWorkouts { get; }
    public IEnumerable<UserWorkout> UserWorkouts { get; }
    public IEnumerable<ExerciseWorkout> ExerciseWorkouts { get; }
    
    public IEnumerable<UserWorkoutSession> UserWorkoutSessions { get; }
}