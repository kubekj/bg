using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class UserWorkoutSessionConfiguration : IEntityTypeConfiguration<UserWorkoutSession>
{
    public void Configure(EntityTypeBuilder<UserWorkoutSession> builder)
    {
        builder.HasKey(uws => new { uws.UserId, uws.WorkoutId, uws.Date });
        builder
            .HasOne(uws => uws.UserWorkout)
            .WithMany(u => u.UserWorkoutSessions)
            .HasForeignKey(uws => new {uws.UserId, uws.WorkoutId});
    }
}