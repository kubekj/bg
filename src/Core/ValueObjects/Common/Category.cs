using Core.Exceptions.Shared;
using Core.SeedWork;

namespace Core.ValueObjects.Common;

public class Category : ValueObject
{
    public const string Upper = nameof(Upper);
    public const string Lower = nameof(Lower);
    public const string Full = nameof(Full);
    public const string Cardio = nameof(Cardio);
    
    public Category(string value)
    {
        if (value is not (Upper or Lower or Full or Cardio))
            throw new IncorrectCategoryException(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(Category category) => category.Value;

    public static implicit operator Category(string value) => new(value);

    public override string ToString() => Value;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}