using Core.SeedWork;
using Core.ValueObjects.Properties.Measurement;

namespace Core.Entities;

public class Measurement : Entity
{
    public Measurement(Guid id) : base(id)
    {
    }
    
    public BodyWeight Weight { get; private set; }
    public BodyHeight Height { get; private set; }
    
    public User User { get; private set; }
    public Guid UserId { get; private set; }
}