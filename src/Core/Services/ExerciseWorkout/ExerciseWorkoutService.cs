using Core.Entities;
using Core.Repositories;

namespace Core.Services.ExerciseWorkout;

public class ExerciseWorkoutService : IExerciseWorkoutService
{
    private readonly IExerciseWorkoutRepository _exerciseWorkoutRepository;
    private readonly ISetRepository _setRepository;

    public ExerciseWorkoutService(IExerciseWorkoutRepository exerciseWorkoutRepository, ISetRepository setRepository)
    {
        _exerciseWorkoutRepository = exerciseWorkoutRepository;
        _setRepository = setRepository;
    }

    public async Task HandleExerciseWithSetsCreation(Guid workoutId,IDictionary<Guid, IEnumerable<Set>> exerciseWithSets)
    {
        foreach (var exercise in exerciseWithSets)
        {
            var sets = new HashSet<Set>();
            foreach (var setDto in exercise.Value)
                sets.Add(new Set(Guid.NewGuid(), setDto.Repetitions, setDto.Weight));
            await _exerciseWorkoutRepository.AddAsync(new Entities.ExerciseWorkout(exercise.Key, workoutId, sets));
        }
    }

    public async Task HandleExerciseWithSetsEdition(Guid workoutId, IDictionary<Guid, IEnumerable<Set>> exerciseWithSets)
    {
        var existingExercises = (await GetExercisesForWorkoutAsync(workoutId)).ToList();
        var existingSets = await GetSetsForWorkoutAsync(workoutId);

        var exercisesToDelete = existingExercises.Except(exerciseWithSets.Keys);
        foreach (var exerciseId in exercisesToDelete)
        {
            exerciseWithSets.Remove(exerciseId);
            await _exerciseWorkoutRepository.RemoveAsync(exerciseId, workoutId);
        }
        
        foreach (var (exerciseId, sets) in exerciseWithSets)
        {
            if (existingExercises.Contains(exerciseId))
            {
                var existingExerciseSets = existingSets[exerciseId].ToList();
                foreach (var set in existingExerciseSets) await _setRepository.RemoveAsync(set);
                foreach (var set in sets) await _setRepository.AddAsync(new Set(Guid.NewGuid(), set.Repetitions,set.Weight,workoutId,exerciseId));
            }
            else
            {
                var newSets = sets.Select(s => new Set(Guid.NewGuid(), s.Repetitions, s.Weight,workoutId,exerciseId)).ToList();
                await _exerciseWorkoutRepository.AddAsync(new Entities.ExerciseWorkout(exerciseId,workoutId,newSets));
            }
        }
    }

    public async Task<IEnumerable<Guid>> GetExercisesForWorkoutAsync(Guid workoutId)
    {
        var exerciseWorkouts = await _exerciseWorkoutRepository.GetAllAsync(x => x.WorkoutId == workoutId);
        return exerciseWorkouts.Select(x => x.ExerciseId);
    }

    public async Task<IDictionary<Guid, IEnumerable<Set>>> GetSetsForWorkoutAsync(Guid workoutId)
    {
        var exerciseWorkouts = await _exerciseWorkoutRepository.GetAllAsync(x => x.WorkoutId == workoutId);
        return exerciseWorkouts.ToDictionary(x => x.ExerciseId, x => x.Sets);
    }
}