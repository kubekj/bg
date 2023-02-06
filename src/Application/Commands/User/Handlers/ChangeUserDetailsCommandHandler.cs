using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;
using Core.Shared;
using Core.ValueObjects.Common;
using Core.ValueObjects.Language;
using Core.ValueObjects.Measurement;
using Core.ValueObjects.User;


namespace Application.Commands.User.Handlers;

public class ChangeUserDetailsCommandHandler : ICommandHandler<ChangeUserDetailsCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IClock _clock;

    public ChangeUserDetailsCommandHandler(IUserRepository userRepository, 
        IMeasurementRepository measurementRepository, 
        IClock clock)
    {
        _userRepository = userRepository;
        _measurementRepository = measurementRepository;
        _clock = clock;
    }

    public async Task HandleAsync(ChangeUserDetailsCommand command)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);

        if (user is null)
            return;

        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var email = new Email(command.Email);
        var bio = new Description(command.Bio);
        var language = new Language(command.PreferredLanguage);

        var weight = new BodyWeight(command.Weight);
        var weightGoal = new BodyWeight(command.WeightGoal);
        var height = new BodyHeight(command.Height);
        var caloriesIntake = new CaloriesIntake(command.CaloriesIntake);
        var caloriesIntakeGoal = new CaloriesIntake(command.CaloriesIntakeGoal);

        user.ChangeDetails(firstName,lastName,email,language,bio);
        var measurement = new Measurement(Guid.NewGuid(),user.Id,weight,height,caloriesIntake,_clock.Current(),weightGoal,caloriesIntakeGoal);
        
        await _userRepository.EditUserDetails(user);
        await _measurementRepository.AddAsync(measurement);
    }
}