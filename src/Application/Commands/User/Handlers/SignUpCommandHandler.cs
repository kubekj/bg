using System;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Command;
using Application.Exceptions;
using Application.Security;
using Core.Entities;
using Core.Repositories;
using Core.Shared;
using Core.ValueObjects.User;

namespace Application.Commands.User.Handlers;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IClock _clock;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;
    private readonly IMeasurementRepository _measurementRepository;
    const string January = "January 1, 2023";

    public SignUpCommandHandler(IUserRepository userRepository, 
        IPasswordManager passwordManager, 
        IClock clock, 
        IMeasurementRepository measurementRepository)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
        _measurementRepository = measurementRepository;
    }

    public async Task HandleAsync(SignUpCommand command)
    {
        var userId = Guid.NewGuid();
        var email = new Email(command.Email);
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var password = new Password(command.Password);

        if (await _userRepository.GetByEmailAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        var securedPassword = _passwordManager.Hash(password);

        var user = new Core.Entities.User(userId, firstName, lastName, email, securedPassword, _clock.Current());
        
        await _measurementRepository.AddAsync(new Measurement(Guid.NewGuid(),
            userId,
            0,
            0,
            0,
            DateTime.Parse(January), 0, 0));
        await _userRepository.AddAsync(user);
    }
}