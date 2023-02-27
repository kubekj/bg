using System;
using System.Threading.Tasks;
using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;

namespace Application.Commands.Goals.Handlers;

public class SetGoalCommandHandler : ICommandHandler<SetGoalCommand>
{
    private readonly IGoalRepository _goalRepository;

    public SetGoalCommandHandler(IGoalRepository goalRepository) => _goalRepository = goalRepository;

    public async Task HandleAsync(SetGoalCommand command)
    {
        var currentGoal = await _goalRepository.GetByMonth(command.UserId);
        
        if (currentGoal is null)
        {
            await _goalRepository.AddAsync(new Goal(Guid.NewGuid(), command.Goal, command.UserId));
            return;
        }
        
        currentGoal.EditGoal(command.Goal);
        
        await _goalRepository.EditAsync(currentGoal);
    }
}