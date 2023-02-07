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

        double weight = userLatestMeasurement?.Weight ?? 0;
        double weightGoal = userLatestMeasurement?.WeightGoal ?? 0;
        double height = userLatestMeasurement?.Height ?? 0;
        int caloriesIntake = userLatestMeasurement?.CaloriesIntake ?? 0;
        int caloriesIntakeGoal = userLatestMeasurement?.CaloriesIntakeGoal ?? 0;

        return new UserDto(userInfo.FirstName,userInfo.LastName,userInfo.Email,userInfo.Bio,userInfo.PreferredLanguage,
            weight,weightGoal,height,caloriesIntake,caloriesIntakeGoal);
    }
}