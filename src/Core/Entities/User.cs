using System.Runtime.InteropServices.ComTypes;
using Core.SeedWork;
using Core.ValueObjects.Common;
using Core.ValueObjects.Language;
using Core.ValueObjects.User;

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
        Bio = $"Hey there, my name is {firstName} {lastName} !";
        Measurements = new HashSet<Measurement>();
        Goals = new HashSet<Goal>();
        AllowedTrainings = new HashSet<UserTrainingPlan>();
        CreatedTrainingPlans = new HashSet<TrainingPlan>();
        UserWorkouts = new HashSet<UserWorkout>();
        UserExercises = new HashSet<UserExercise>();
        Ratings = new HashSet<Rating>();
    }

    public void ChangeDetails(FirstName firstName, LastName lastName, Email email,Language preferredLanguage ,Description bio)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PreferredLanguage = preferredLanguage;
        Bio = bio;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set;}
    public Email Email { get; private set;}
    public Password Password { get; private set;}
    public DateTime CreatedAt { get; }
    public Role Role { get; private set;}
    public Language PreferredLanguage { get; private set;}
    public Description Bio { get; private set;}
    public IEnumerable<Measurement>? Measurements { get; }
    public IEnumerable<Goal> Goals { get; }
    public IEnumerable<UserTrainingPlan> AllowedTrainings { get; }
    public IEnumerable<UserExercise> UserExercises { get; }
    public IEnumerable<TrainingPlan> CreatedTrainingPlans { get; }
    public IEnumerable<UserWorkout> UserWorkouts { get; }
    public IEnumerable<Rating> Ratings { get; }

    public void RegisterAsTrainer() => Role = Role.Trainer();
}