using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class TrainingPlanWorkoutConfiguration : IEntityTypeConfiguration<TrainingPlanWorkout>
{
    public void Configure(EntityTypeBuilder<TrainingPlanWorkout> builder)
    {
        builder.HasKey(e => new { e.WorkoutId, e.TrainingPlanId });
        builder.HasOne(e => e.Workout)
            .WithMany(e => e.TrainingPlanWorkouts)
            .HasForeignKey(e => e.WorkoutId);
        builder.HasOne(e => e.TrainingPlan)
            .WithMany(e => e.TrainingPlanWorkouts)
            .HasForeignKey(e => e.TrainingPlanId);
    }
}