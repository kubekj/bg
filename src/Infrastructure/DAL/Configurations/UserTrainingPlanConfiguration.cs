using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class UserTrainingPlanConfiguration : IEntityTypeConfiguration<UserTrainingPlan>
{
    public void Configure(EntityTypeBuilder<UserTrainingPlan> builder)
    {
        builder.HasKey(e => new { e.UserId, e.TrainingPlanId });
        builder.HasOne(e => e.User)
            .WithMany(e => e.AllowedTrainings)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        builder.HasOne(e => e.TrainingPlan)
            .WithMany(e => e.AllowedUsers)
            .HasForeignKey(e => e.TrainingPlanId)
            .IsRequired();
        builder.Property(e => e.BoughtAt).IsRequired();
    }
}