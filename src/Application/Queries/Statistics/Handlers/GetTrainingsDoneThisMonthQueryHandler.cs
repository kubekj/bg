using Application.Abstractions.Messaging.Query;
using Core.Repositories;
using Core.Shared;

namespace Application.Queries.Statistics.Handlers;

public class GetTrainingsDoneThisMonthQueryHandler : IQueryHandler<GetTrainingsDoneThisMonthQuery,Tuple<int,int>>
{
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepository;
    private readonly IGoalRepository _goalRepository;
    private readonly IClock _clock;

    public GetTrainingsDoneThisMonthQueryHandler(IUserWorkoutSessionRepository userWorkoutSessionRepository, 
        IGoalRepository goalRepository, IClock clock)
    {
        _userWorkoutSessionRepository = userWorkoutSessionRepository;
        _goalRepository = goalRepository;
        _clock = clock;
    }

    public async Task<Tuple<int, int>> HandleAsync(GetTrainingsDoneThisMonthQuery query)
    {
        var doneTrainingsThisMonth = await _userWorkoutSessionRepository
            .GetAllAsync(x => x.UserId == query.UserId && x.Date < _clock.Current() && x.Date.Month == _clock.Current().Month);
        var currentGoal = await _goalRepository.GetByMonth(query.UserId);

        return new Tuple<int, int>(doneTrainingsThisMonth.Count(), currentGoal);
    }
}