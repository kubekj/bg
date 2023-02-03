using Core.Shared;

namespace Core.Services.UserWorkoutSession;

public class UserWorkoutSessionService : IUserWorkoutSessionService
{
    public Entities.Workout? GetPreviousUserWorkoutSession(IEnumerable<Entities.UserWorkoutSession> userWorkoutSessions)
        => userWorkoutSessions
            // .Where(x => x.IsDone)
            .MaxBy(x => x.Date)?.UserWorkout.Workout;

    public Entities.Workout? GetCurrentUserWorkoutSession(IEnumerable<Entities.UserWorkoutSession> userWorkoutSessions, IClock clock)
        => userWorkoutSessions.FirstOrDefault(x => !x.IsDone && x.Date.Month == clock.Current().Month && x.Date.Day == clock.Current().Day)?.UserWorkout.Workout;

    public Entities.Workout? GetNextUserWorkoutSession(IEnumerable<Entities.UserWorkoutSession> userWorkoutSessions) 
        => userWorkoutSessions.Where(x => !x.IsDone).MinBy(x => x.Date)?.UserWorkout.Workout;
}