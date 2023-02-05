using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetAllWorkoutSessionsQueryHandler : IQueryHandler<GetAllWorkoutSessionsQuery,IEnumerable<WorkoutSessionDto>>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;

    public GetAllWorkoutSessionsQueryHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
    }

    public async Task<IEnumerable<WorkoutSessionDto>> HandleAsync(GetAllWorkoutSessionsQuery query)
    {
        var userSessions = await _userWorkoutSessionRepository
            .GetAllAsync(usw => usw.UserId == query.UserId);

        return userSessions.Select(us => new WorkoutSessionDto(us.UserWorkout.Workout.Adapt<WorkoutDto>(), us.Date));
    }
}