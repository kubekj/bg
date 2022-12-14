using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class UserWorkoutConfiguration : IEntityTypeConfiguration<UserWorkout>
{
    public void Configure(EntityTypeBuilder<UserWorkout> builder)
    {
        builder.HasKey(e => new { e.UserId, e.WorkoutId });
        builder.HasOne(e => e.User)
            .WithMany(e => e.UserWorkouts)
            .HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Workout)
            .WithMany(e => e.UserWorkouts)
            .HasForeignKey(e => e.WorkoutId);
    }
}