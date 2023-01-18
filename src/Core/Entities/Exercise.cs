using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.Exercise;

namespace Core.Entities;

public class Exercise : Entity
{
    public Exercise(Guid id, ExerciseName name, BodyPart bodyPart, Category category) : base(id)
    {
        Name = name;
        BodyPart = bodyPart;
        Category = category;
        Sets = new HashSet<Set>();
        ExerciseWorkouts = new HashSet<ExerciseWorkout>();
        UserExercises = new HashSet<UserExercise>();
    }

    public Exercise CreateCopyForUser(string? name = default, string? bodyPart = default, string? category = default) =>
        new(Guid.NewGuid(), name ?? Name, bodyPart ?? BodyPart, category ?? Category);

    public ExerciseName Name { get; }
    public BodyPart BodyPart { get; }
    public Category Category { get; }
    public IEnumerable<Set> Sets { get; }
    public IEnumerable<ExerciseWorkout> ExerciseWorkouts { get; }
    public IEnumerable<UserExercise> UserExercises { get; }
}