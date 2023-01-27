using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;

namespace Application.Queries.User.Handlers;

public class GetPersonalInfoQueryHandler : IQueryHandler<GetPersonalInfoQuery,UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMeasurementRepository _measurementRepository;

    public GetPersonalInfoQueryHandler(IUserRepository userRepository, IMeasurementRepository measurementRepository)
    {
        _userRepository = userRepository;
        _measurementRepository = measurementRepository;
    }

    public async Task<UserDto> HandleAsync(GetPersonalInfoQuery query)
    {
        var userInfo = await _userRepository.GetByIdAsync(query.UserId);
        var userLatestMeasurement = await _measurementRepository.GetForUserAsync(query.UserId);

        return new UserDto(userInfo.FirstName,userInfo.LastName,userInfo.Email,userInfo.Bio,userInfo.PreferredLanguage,
            userLatestMeasurement.Weight,userLatestMeasurement.Height,userLatestMeasurement.CaloriesIntake);
    }
}