using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Application.Exceptions;
using Core.Repositories;
using Core.Services.UserWorkoutSession;
using Core.Shared;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetCurrentWorkoutQueryHandler : IQueryHandler<GetCurrentWorkoutQuery,WorkoutDto>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;
    private readonly IUserWorkoutSessionService _userWorkoutSessionService;
    private readonly IClock _clock;

    public GetCurrentWorkoutQueryHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository,
        IUserWorkoutSessionService userWorkoutSessionService, IClock clock)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
        _userWorkoutSessionService = userWorkoutSessionService;
        _clock = clock;
    }

    public async Task<WorkoutDto> HandleAsync(GetCurrentWorkoutQuery query)
    {
        var userSessions = await _userWorkoutSessionRepository.GetAllAsync(usw => usw.UserId == query.UserId);
        var workout = _userWorkoutSessionService.GetCurrentUserWorkoutSession(userSessions,_clock);

        if (workout is null) throw new NoWorkoutFoundException();

        return workout.Adapt<WorkoutDto>();
    }
}