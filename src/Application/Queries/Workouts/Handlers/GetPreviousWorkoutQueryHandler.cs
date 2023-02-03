using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Application.Exceptions;
using Core.Repositories;
using Core.Services.UserWorkoutSession;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetPreviousWorkoutQueryHandler : IQueryHandler<GetPreviousWorkoutQuery,WorkoutDto>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;
    private readonly IUserWorkoutSessionService _userWorkoutSessionService;

    public GetPreviousWorkoutQueryHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository,
        IUserWorkoutSessionService userWorkoutSessionService)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
        _userWorkoutSessionService = userWorkoutSessionService;
    }

    public async Task<WorkoutDto> HandleAsync(GetPreviousWorkoutQuery query)
    {
        var userSessions = await _userWorkoutSessionRepository.GetAllAsync(usw => usw.UserId == query.UserId);
        var workout = _userWorkoutSessionService.GetPreviousUserWorkoutSession(userSessions);

        if (workout is null) throw new NoWorkoutFoundException();

        return workout.Adapt<WorkoutDto>();
    }
}