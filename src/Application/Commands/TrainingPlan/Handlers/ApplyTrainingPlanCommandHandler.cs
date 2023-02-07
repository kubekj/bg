using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;

namespace Application.Commands.TrainingPlan.Handlers;

public class ApplyTrainingPlanCommandHandler : ICommandHandler<ApplyTrainingPlanCommand>
{
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly ITrainingPlanWorkoutRepository _trainingPlanWorkoutRepository;
    private readonly IUserTrainingPlanRepository _userTrainingPlanRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IUserWorkoutSessionRepository _userWorkoutSessionRepositoryRepository;

    public ApplyTrainingPlanCommandHandler(ITrainingPlanRepository trainingPlanRepository, 
        ITrainingPlanWorkoutRepository trainingPlanWorkoutRepository, 
        IUserWorkoutRepository userWorkoutRepository, 
        IUserWorkoutSessionRepository userWorkoutSessionRepositoryRepository, 
        IUserTrainingPlanRepository userTrainingPlanRepository)
    {
        _trainingPlanRepository = trainingPlanRepository;
        _trainingPlanWorkoutRepository = trainingPlanWorkoutRepository;
        _userWorkoutRepository = userWorkoutRepository;
        _userWorkoutSessionRepositoryRepository = userWorkoutSessionRepositoryRepository;
        _userTrainingPlanRepository = userTrainingPlanRepository;
    }

    public async Task HandleAsync(ApplyTrainingPlanCommand command)
    {
        var userTrainingPlan = await _userTrainingPlanRepository.GetByIdAsync(command.UserId,command.TrainingPlanId);

        if (userTrainingPlan is null)
            return;

        var workoutSessions = (await _userWorkoutSessionRepositoryRepository
            .GetAllAsync(x => x.UserId == command.UserId)).ToList();

        var dateFrom = command.StartDate;

        var workouts = userTrainingPlan.TrainingPlan.TrainingPlanWorkouts.Select(x => x.Workout).ToList();
        
        var dates = DetermineDates(dateFrom,(int)userTrainingPlan.TrainingPlan.Duration,workouts.Count());
        
        var counter = 0;
        foreach (var date in dates)
        {
            var existingUserSession = workoutSessions.FirstOrDefault(x => x.Date == date);
            
            if (existingUserSession is not null)
            {
                existingUserSession.Edit(workouts[counter].Id);
                await _userWorkoutSessionRepositoryRepository.EditAsync(existingUserSession);
            }
            else
            {
                if (await _userWorkoutRepository.GetByIdAsync(command.UserId,workouts[counter].Id) is null)
                    await _userWorkoutRepository.AddAsync(new UserWorkout(workouts[counter].Id, command.UserId));
                
                await _userWorkoutSessionRepositoryRepository.AddAsync(new UserWorkoutSession(command.UserId,workouts[counter].Id,date));
            }
            
            counter++;
            if (counter == workouts.Count) counter = 0;
        }
    }

    private static List<DateTime> DetermineDates(DateTime from, int numOfWeeks, int numOfWorkouts)
    {
        var totalWorkouts = numOfWeeks * numOfWorkouts;
        var restDays = 7 - numOfWorkouts;
        var startDate = DateTime.Today;
        var workoutDates = new List<DateTime>();
        
        for (var i = 0; i < totalWorkouts; i++)
        {
            workoutDates.Add(startDate);

            if (workoutDates.Count % numOfWorkouts == 0 && (workoutDates.Count > 0 && restDays > 0))
            {
                startDate = startDate.AddDays(1);
                startDate = startDate.AddDays(restDays);
                restDays = 7 - numOfWorkouts;
            }
            else
            {
                startDate = startDate.AddDays(1);
            }
        }

        return workoutDates;
    }
}