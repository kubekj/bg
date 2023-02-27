using System.Threading.Tasks;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetWorkoutQueryHandler : IQueryHandler<GetWorkoutQuery,WorkoutDto>
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetWorkoutQueryHandler(IWorkoutRepository workoutRepository) => _workoutRepository = workoutRepository;

    public async Task<WorkoutDto> HandleAsync(GetWorkoutQuery query)
    {
        var result = await _workoutRepository.GetByIdAsync(query.WorkoutId, query.UserId);
        return result.Adapt<WorkoutDto>();
    }
}