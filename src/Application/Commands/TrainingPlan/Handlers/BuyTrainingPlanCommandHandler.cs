using Application.Abstractions.Messaging.Command;
using Core.Entities;
using Core.Repositories;

namespace Application.Commands.TrainingPlan.Handlers;

public class BuyTrainingPlanCommandHandler : ICommandHandler<BuyTrainingPlanCommand>
{
    private readonly IUserTrainingPlanRepository _userTrainingPlanRepository;
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IUserExerciseRepository _userExerciseRepository;
    private readonly ITrainingPlanRepository _trainingPlanRepository;

    public BuyTrainingPlanCommandHandler(IUserTrainingPlanRepository userTrainingPlanRepository, 
        IUserWorkoutRepository userWorkoutRepository, 
        IUserExerciseRepository userExerciseRepository, 
        ITrainingPlanRepository trainingPlanRepository)
    {
        _userTrainingPlanRepository = userTrainingPlanRepository;
        _userWorkoutRepository = userWorkoutRepository;
        _userExerciseRepository = userExerciseRepository;
        _trainingPlanRepository = trainingPlanRepository;
    }

    //If user have workouts / exercises already just skip
    
    public async Task HandleAsync(BuyTrainingPlanCommand command)
    {
        var userTrainingPlans = await _userTrainingPlanRepository.GetAllAsync(x => x.UserId == command.UserId);

        if (userTrainingPlans.Any(x => x.TrainingPlanId == command.TrainingPlanId))
            return;

        var trainingPlan = await _trainingPlanRepository.GetByIdAsync(command.TrainingPlanId);

        var userWorkouts = new HashSet<Guid>();
        
        foreach (var tpw in trainingPlan.TrainingPlanWorkouts)
        {
            foreach (var ew in tpw.Workout.ExerciseWorkouts)
            {
                if (userWorkouts.Any(x => x == ew.ExerciseId))
                    continue;

                userWorkouts.Add(ew.ExerciseId);
            }

            var userWorkout = await _userWorkoutRepository.GetByIdAsync(command.UserId,tpw.WorkoutId);
            if (userWorkout is not null)
                continue;
            await _userWorkoutRepository.AddAsync(new UserWorkout(tpw.WorkoutId, command.UserId));
        }

        foreach (var exerciseId in userWorkouts)
        {
            var userExercise = await _userExerciseRepository.GetByIdAsync(command.UserId,exerciseId);
            if (userExercise is not null)
                continue;
            await _userExerciseRepository.AddAsync(new UserExercise(exerciseId, command.UserId));
        }

        await _userTrainingPlanRepository.AddAsync(new UserTrainingPlan(command.UserId,command.TrainingPlanId));
    }
}