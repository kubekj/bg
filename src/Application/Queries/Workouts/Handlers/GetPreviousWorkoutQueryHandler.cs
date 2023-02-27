using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Application.Exceptions;
using Core.Repositories;
using Core.Services.UserWorkoutSession;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetPreviousWorkoutQueryHandler : IQueryHandler<GetPreviousWorkoutQuery,Tuple<WorkoutDto,DateTime>>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;
    private readonly IUserWorkoutSessionService _userWorkoutSessionService;

    public GetPreviousWorkoutQueryHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository,
        IUserWorkoutSessionService userWorkoutSessionService)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
        _userWorkoutSessionService = userWorkoutSessionService;
    }

    public async Task<Tuple<WorkoutDto,DateTime>> HandleAsync(GetPreviousWorkoutQuery query)
    {
        var userSessions = await _userWorkoutSessionRepository.GetAllAsync(usw => usw.UserId == query.UserId);
        var workout = _userWorkoutSessionService.GetPreviousUserWorkoutSession(userSessions);

        if (workout is null) throw new NoWorkoutFoundException();

        var previousDate = userSessions
            .OrderByDescending(x => x.Date)
            .FirstOrDefault(x => x.Date < DateTime.Now).Date;
        
        return new Tuple<WorkoutDto, DateTime>(workout.Adapt<WorkoutDto>(),previousDate);
    }
}