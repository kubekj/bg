using Core.Enums;
using Core.SeedWork;
using Core.ValueObjects;
using Core.ValueObjects.Properties.User;

namespace Core.Entities;

public class User : Entity
{
    public User(Guid id,FirstName firstName, LastName lastName, Email email, Password password, DateTime createdAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        Role = Role.Athlete();
        PreferredLanguage = Language.English();
    }
    
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Role Role { get; private set; }
    public Language PreferredLanguage { get; private set; }
    public Measurement? Measurement { get; private set; }
    public IEnumerable<Goal> Goals { get; private set; }
    public IEnumerable<UserTrainingPlan> AllowedTrainings { get; private set; }
    public IEnumerable<UserWorkout> UserWorkouts { get; private set; }
    
    
}