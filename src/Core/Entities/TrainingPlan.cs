using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.Properties.Common;
using Core.ValueObjects.Properties.TrainingPlan;

namespace Core.Entities;

public class TrainingPlan : Entity
{
    public TrainingPlan(Guid id) : base(id) { }
    
    public TrainingPlan(Guid id, Duration duration, Price price, SkillLevel skillLevel, Title title,
        Description description, User author, Status status) : base(id)
    {
        Duration = duration;
        Price = price;
        SkillLevel = skillLevel;
        Title = title;
        Description = description;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
        Author = author;
        Status = status;
        AllowedUsers = new HashSet<UserTrainingPlan>();
        Ratings = new HashSet<Rating>();
    }

    public Duration Duration { get; }
    public Price Price { get; }
    public SkillLevel SkillLevel { get; }
    public Title Title { get; }
    public Description Description { get; }
    public Status Status { get; }

    public Guid AuthorId { get; private set; }
    public User Author { get; }

    public IEnumerable<Rating> Ratings { get; }
    public IEnumerable<UserTrainingPlan> AllowedUsers { get; }
    public IEnumerable<TrainingPlanWorkout> TrainingPlanWorkouts { get; }
}