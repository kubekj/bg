using Core.SeedWork;
using Core.ValueObjects.Measurement;

namespace Core.Entities;

public class Measurement : Entity
{
    public Measurement(Guid id, BodyWeight weight, BodyHeight height) : base(id)
    {
        Weight = weight;
        Height = height;
    }

    public BodyWeight Weight { get; }
    public BodyHeight Height { get; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
}