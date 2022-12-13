using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects.Properties.Common;
using Core.ValueObjects.Properties.TrainingPlan;

namespace Core.Entities;

public class TrainingPlan : Entity
{
    public TrainingPlan(Guid id, Duration duration, Price price, SkillLevel skillLevel, Title title,
        Description description, User author, Status status) : base(id)
    {
        Duration = duration;
        Price = price;
        SkillLevel = skillLevel;
        Title = title;
        Description = description;
        Workouts = new HashSet<TrainingPlanWorkout>();
        Author = author;
        Status = status;
        AllowedUsers = new HashSet<UserTrainingPlan>();
        Ratings = new HashSet<Rating>();
    }

    public Duration Duration { get; private set; }
    public Price Price { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Status Status { get; private set; }
    
    public Guid AuthorId { get; private set; }
    public User Author { get; private set; }
    
    public IEnumerable<Rating> Ratings { get; private set; }
    public IEnumerable<UserTrainingPlan> AllowedUsers { get; private set; }
    public IEnumerable<TrainingPlanWorkout> Workouts { get; private set; }
}