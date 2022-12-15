using Core.Entities;
using Core.ValueObjects.Properties.Common;
using Core.ValueObjects.Properties.Rating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Rate)
            .HasConversion(e => e.Value, e => new Rate(e))
            .IsRequired()
            .HasMaxLength(Rate.MaxRate);
        builder.Property(e => e.Description)
            .HasConversion(e => e.Value, e => new Description(e))
            .IsRequired()
            .HasMaxLength(Description.MaxLength);

        builder.HasOne(e => e.User)
            .WithMany(e => e.Ratings)
            .HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.TrainingPlan)
            .WithMany(e => e.Ratings)
            .HasForeignKey(e => e.TrainingPlanId);
    }
}