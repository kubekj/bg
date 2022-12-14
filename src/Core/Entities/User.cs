using Core.SeedWork;
using Core.ValueObjects.Properties.Language;
using Core.ValueObjects.Properties.User;

namespace Core.Entities;

public class User : Entity
{
    public User(Guid id, FirstName firstName, LastName lastName, Email email, Password password,
        DateTime createdAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        Role = Role.Athlete();
        PreferredLanguage = Language.English;
        Measurements = new HashSet<Measurement>();
        Goals = new HashSet<Goal>();
        AllowedTrainings = new HashSet<UserTrainingPlan>();
        UserWorkouts = new HashSet<UserWorkout>();
        Ratings = new HashSet<Rating>();
    }

    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Email Email { get; }
    public Password Password { get; }
    public DateTime CreatedAt { get; }
    public Role Role { get; }
    public Language PreferredLanguage { get; }
    public IEnumerable<Measurement>? Measurements { get; }
    public IEnumerable<Goal> Goals { get; }
    public IEnumerable<UserTrainingPlan> AllowedTrainings { get; }
    public IEnumerable<UserWorkout> UserWorkouts { get; }
    public IEnumerable<Rating> Ratings { get; }
}