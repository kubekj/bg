using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class UserExerciseConfiguration : IEntityTypeConfiguration<UserExercise>
{
    public void Configure(EntityTypeBuilder<UserExercise> builder)
    {
        builder.HasKey(e => new { e.UserId, e.ExerciseId });
        builder.HasOne(e => e.User)
            .WithMany(e => e.UserExercises)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        builder.HasOne(e => e.Exercise)
            .WithMany(e => e.UserExercises)
            .HasForeignKey(e => e.ExerciseId)
            .IsRequired();
    }
}