using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.Properties.Exercise;

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
    }

    public ExerciseName Name { get; }
    public BodyPart BodyPart { get; }
    public Category Category { get; }
    public IEnumerable<Set> Sets { get; }
    public IEnumerable<ExerciseWorkout> ExerciseWorkouts { get; }
}