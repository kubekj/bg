using Core.Shared;

namespace Core.Services.UserWorkoutSession;

public interface IUserWorkoutSessionService
{
    public Entities.Workout? GetPreviousUserWorkoutSession(IEnumerable<Entities.UserWorkoutSession> userWorkoutSessions);
    public Entities.Workout? GetCurrentUserWorkoutSession(IEnumerable<Entities.UserWorkoutSession> userWorkoutSessions, IClock clock);
    public Entities.Workout? GetNextUserWorkoutSession(IEnumerable<Entities.UserWorkoutSession> userWorkoutSessions);
}