using Core.Exceptions;

namespace Infrastructure.Exceptions;

internal class UserNotFoundException : CoreException
{
    public UserNotFoundException(Guid id) : base("")
    {
        Value = id;
    }

    public Guid Value { get; set; }
}