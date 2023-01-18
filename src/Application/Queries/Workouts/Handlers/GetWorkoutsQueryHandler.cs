using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;
using Core.Repositories;
using Mapster;

namespace Application.Queries.Workouts.Handlers;

public class GetWorkoutsQueryHandler : IQueryHandler<GetWorkoutsQuery,IEnumerable<WorkoutDto>>
{
    private readonly IUserWorkoutRepository _userWorkoutRepository;
    private readonly IWorkoutRepository _workoutRepository;

    public GetWorkoutsQueryHandler(IUserWorkoutRepository userWorkoutRepository, IWorkoutRepository workoutRepository)
    {
        _userWorkoutRepository = userWorkoutRepository;
        _workoutRepository = workoutRepository;
    }

    public async Task<IEnumerable<WorkoutDto>> HandleAsync(GetWorkoutsQuery query)
    {
        var userWorkouts = (await _workoutRepository
            .GetAllAsync(query.UserId)).ToList();

        return userWorkouts.Adapt<IEnumerable<WorkoutDto>>();
        // var exercises = userWorkouts
        //     .Select(x => x.Workout)
        //     .Select(x => x.ExerciseWorkouts)
        //     .Select(x => x.Select(e=> e.Exercise))
        //     .ToList();
        //
        // var workoutDtos = new HashSet<WorkoutDto>();
        //
        // foreach (var userWorkout in userWorkouts)
        //     workoutDtos.Add(new WorkoutDto(userWorkout.Workout.Name, userWorkout.Workout.Category,
        //         exercises.First().Adapt<IEnumerable<ExerciseDto>>()));
        //
        // return workoutDtos;
    }
}