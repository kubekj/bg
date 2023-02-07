using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.Language;
using Core.ValueObjects.TrainingPlan;

namespace Core.Entities;

public class TrainingPlan : Entity
{
    public TrainingPlan(Guid id, Duration duration, Price price, SkillLevel skillLevel, Title title,
        Description description, Guid authorId, Status status, Language language) : base(id)
    {
        Duration = duration;
        Price = price;
        SkillLevel = skillLevel;
        Title = title;
        Description = description;
        TrainingPlanWorkouts = new HashSet<TrainingPlanWorkout>();
        AuthorId = authorId;
        Status = status;
        Language = language;
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        AllowedUsers = new HashSet<UserTrainingPlan>();
        Ratings = new HashSet<Rating>();
    }

    public TrainingPlan MarkAsDeleted(TrainingPlan trainingPlan)
    {
        trainingPlan.IsDeleted = true;
        trainingPlan.Status = Status.Unpublished;
        return trainingPlan;
    }

    public Duration Duration { get; private set;}
    public Price Price { get; private set;}
    public SkillLevel SkillLevel { get; private set;}
    public Title Title { get;private set; }
    public Description Description { get; private set;}
    public Status Status { get; private set; }
    public Language Language { get;private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; } 

    public Guid AuthorId { get; }
    public User Author { get; }

    public IEnumerable<Rating> Ratings { get; }
    public IEnumerable<UserTrainingPlan> AllowedUsers { get; }
    public IEnumerable<TrainingPlanWorkout> TrainingPlanWorkouts { get; }

    public void Update(Duration duration, Price price, SkillLevel skillLevel, Title title, Description description, Status status, Language language)
    {
        Duration = duration;
        Price = price;
        SkillLevel = skillLevel;
        Title = title;
        Description = description;
        Status = status;
        Language = language;
    }
}