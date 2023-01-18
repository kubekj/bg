using Core.Exceptions;

namespace Application.Exceptions;

internal class ExerciseAlreadyAssignedToUserException : CoreException
{
    public ExerciseAlreadyAssignedToUserException(Guid userId, Guid exerciseId)
        : base($"User with Id: {userId} already has an exercise with Id: {exerciseId}")
    {
        UserId = userId;
        ExerciseId = exerciseId;
    }

    public Guid ExerciseId { get; }

    public Guid UserId { get; }
}