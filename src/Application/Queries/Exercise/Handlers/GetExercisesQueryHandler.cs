using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.Exercise.Handlers;

public class GetExercisesQueryHandler : IQueryHandler<GetExercisesQuery, IEnumerable<ExerciseDto>>
{
    private readonly IUserExerciseRepository _userExerciseRepository;

    public GetExercisesQueryHandler(IExerciseRepository exerciseRepository, IUserExerciseRepository userExerciseRepository) => _userExerciseRepository = userExerciseRepository;

    public async Task<IEnumerable<ExerciseDto>> HandleAsync(GetExercisesQuery query)
    {
        var userExercises = await _userExerciseRepository.GetAllForUserAsync(query.userId);
        return userExercises.Select(x => x.Exercise).Adapt<IEnumerable<ExerciseDto>>();
    }
}