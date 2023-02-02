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
        ExerciseWorkouts = new HashSet<ExerciseWorkout>();
        UserExercises = new HashSet<UserExercise>();
    }

    public Exercise Edit(string name, string bodyPart, string category)
    {
        Name = name;
        BodyPart = bodyPart;
        Category = category;
        return this;
    }

    public Exercise CreateCopyForUser(string? name = default, string? bodyPart = default, string? category = default) =>
        new(Guid.NewGuid(), name ?? Name, bodyPart ?? BodyPart, category ?? Category);

    public ExerciseName Name { get; private set; }
    public BodyPart BodyPart { get; private set; }
    public Category Category { get; private set; }
    public IEnumerable<ExerciseWorkout> ExerciseWorkouts { get; }
    public IEnumerable<UserExercise> UserExercises { get; }
}