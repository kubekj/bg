using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.TrainingPlan;

namespace Core.Entities;

public class TrainingPlan : Entity
{
    public TrainingPlan(Guid id, Duration duration, Price price, SkillLevel skillLevel, Title title,
        Description description, Guid authorId, Status status) : base(id)
    {
        Duration = duration;
        Price = price;
        SkillLevel = skillLevel;
        Title = title;
        Description = description;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
        AuthorId = authorId;
        Status = status;
        IsDeleted = false;
        AllowedUsers = new HashSet<UserTrainingPlan>();
        Ratings = new HashSet<Rating>();
    }

    public Duration Duration { get; }
    public Price Price { get; }
    public SkillLevel SkillLevel { get; }
    public Title Title { get; }
    public Description Description { get; }
    public Status Status { get; }
    
    //TODO: Create service to comply with SOLID standards - setter shouldn't be public
    public bool IsDeleted { get; set; } 

    public Guid AuthorId { get; }
    public User Author { get; }

    public IEnumerable<Rating> Ratings { get; }
    public IEnumerable<UserTrainingPlan> AllowedUsers { get; }
    public IEnumerable<TrainingPlanWorkout> TrainingPlanWorkouts { get; }
}