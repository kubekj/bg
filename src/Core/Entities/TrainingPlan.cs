using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.TrainingPlan;

namespace Core.Entities;

public class TrainingPlan : Entity
{
    public TrainingPlan(Guid id, Duration duration, Price price, SkillLevel skillLevel, Title title, Description description) : base(id)
    {
        Duration = duration;
        Price = price;
        SkillLevel = skillLevel;
        Title = title;
        Description = description;
    }

    public Duration Duration { get; private set; }
    public Price Price { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
}