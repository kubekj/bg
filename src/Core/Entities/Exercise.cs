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
    }
    
    public ExerciseName Name { get; private set; }
    public BodyPart BodyPart { get; private set; }
    public Category Category { get; private set; }
    public IEnumerable<Set> Sets { get; private set; }
}