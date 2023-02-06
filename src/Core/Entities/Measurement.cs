using Core.SeedWork;
using Core.ValueObjects.Measurement;

namespace Core.Entities;

public class Measurement : Entity
{
    public Measurement(Guid id, Guid userId, BodyWeight weight, BodyHeight height, CaloriesIntake caloriesIntake, 
        DateTime dateProvided, BodyWeight weightGoal, CaloriesIntake? caloriesIntakeGoal) : base(id)
    {
        UserId = userId;
        Weight = weight;
        Height = height;
        CaloriesIntake = caloriesIntake;
        DateProvided = dateProvided;
        WeightGoal = weightGoal;
        CaloriesIntakeGoal = caloriesIntakeGoal;
    }

    public BodyWeight Weight { get; }
    public BodyWeight WeightGoal { get; }
    public BodyHeight Height { get; }
    public CaloriesIntake? CaloriesIntake { get; }
    public CaloriesIntake? CaloriesIntakeGoal { get; }
    public DateTime DateProvided { get; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
}