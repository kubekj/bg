namespace Core.SeedWork;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public bool Equals(ValueObject? other) => other is not null && ValuesAreEqual(other);

    public abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? obj) => obj is ValueObject vo && ValuesAreEqual(vo);

    public override int GetHashCode() =>
        GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);

    private bool ValuesAreEqual(ValueObject other) => GetAtomicValues().SequenceEqual(other.GetAtomicValues());
}