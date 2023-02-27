using System.Threading.Tasks;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.Exercise.Handlers;

public class GetExerciseQueryHandler : IQueryHandler<GetExerciseQuery,ExerciseDto>
{
    private readonly IUserExerciseRepository _userExerciseRepository;

    public GetExerciseQueryHandler(IUserExerciseRepository userExerciseRepository)
    {
        _userExerciseRepository = userExerciseRepository;
    }

    public async Task<ExerciseDto> HandleAsync(GetExerciseQuery query)
    {
        var userExercise = await _userExerciseRepository.GetByIdAsync(query.UserId,query.ExerciseId);
        return userExercise.Exercise.Adapt<ExerciseDto>();
    }
}