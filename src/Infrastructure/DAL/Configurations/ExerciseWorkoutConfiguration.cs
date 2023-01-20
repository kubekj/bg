using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class ExerciseWorkoutConfiguration : IEntityTypeConfiguration<ExerciseWorkout>
{
    public void Configure(EntityTypeBuilder<ExerciseWorkout> builder)
    {
        builder.HasKey(e => new { e.WorkoutId, e.ExerciseId });
        builder.HasOne(e => e.Workout)
            .WithMany(e => e.ExerciseWorkouts)
            .HasForeignKey(e => e.WorkoutId);
        builder.HasOne(e => e.Exercise)
            .WithMany(e => e.ExerciseWorkouts)
            .HasForeignKey(e => e.ExerciseId);
        
        builder.HasMany(e => e.Sets)
            .WithOne(e => e.ExerciseWorkout)
            .HasForeignKey(e => e.Id);
    }
}