using Domain.Primitives;

namespace Domain.ValueObjects.User;

public class LastName : ValueObject
{
    public override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}