using Core.Exceptions;

namespace Application.Exceptions;

public class NoWorkoutFoundException : CoreException
{
    public NoWorkoutFoundException() : base("There is no workout to show")
    {
    }
}