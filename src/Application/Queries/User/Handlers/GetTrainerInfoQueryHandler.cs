using System.Threading.Tasks;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;

namespace Application.Queries.User.Handlers;

public class GetTrainerInfoQueryHandler : IQueryHandler<GetTrainerInfoQuery,TrainerDto>
{
    private readonly IUserRepository _userRepository;

    public GetTrainerInfoQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<TrainerDto> HandleAsync(GetTrainerInfoQuery query)
    {
        var userInfo = await _userRepository.GetByEmailAsync(query.Email);
        return new TrainerDto(userInfo.FirstName,userInfo.LastName,userInfo.Bio,userInfo.PreferredLanguage,userInfo.Email);
    }
}