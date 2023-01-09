using Core.SeedWork;
using Core.ValueObjects.Measurement;

namespace Core.Entities;

public class Measurement : Entity
{
    public Measurement(Guid id, BodyWeight weight, BodyHeight height, CaloriesIntake caloriesIntake, DateTime dateProvided) : base(id)
    {
        Weight = weight;
        Height = height;
        CaloriesIntake = caloriesIntake;
        DateProvided = dateProvided;
    }

    public BodyWeight Weight { get; }
    public BodyHeight Height { get; }
    public CaloriesIntake? CaloriesIntake { get; }
    public DateTime DateProvided { get; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
}