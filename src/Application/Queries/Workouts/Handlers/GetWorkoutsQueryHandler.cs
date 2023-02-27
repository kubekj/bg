using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetWorkoutsQueryHandler : IQueryHandler<GetWorkoutsQuery,IEnumerable<WorkoutDto>>
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetWorkoutsQueryHandler(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<IEnumerable<WorkoutDto>> HandleAsync(GetWorkoutsQuery query)
    {
        var userWorkouts = (await _workoutRepository
            .GetAllAsync(query.UserId));
        
        return userWorkouts.Adapt<IEnumerable<WorkoutDto>>().ToList();
    }
}