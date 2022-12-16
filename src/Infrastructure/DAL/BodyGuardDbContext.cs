using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

internal sealed class BodyGuardDbContext : DbContext
{
    public BodyGuardDbContext(DbContextOptions<BodyGuardDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Set> Sets { get; set; }
    public DbSet<TrainingPlan> TrainingPlans { get; set; }
    public DbSet<TrainingPlanWorkout> TrainingPlanWorkouts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserTrainingPlan> UserTrainingPlans { get; set; }
    public DbSet<UserWorkout> UserWorkouts { get; set; }
    public DbSet<UserExercise> UserExercises { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}