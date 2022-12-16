namespace Core.Exceptions.Shared.Description;

public class InvalidDescriptionException : CoreException
{
    public InvalidDescriptionException() : base("Description should contain value !")
    {
    }
}