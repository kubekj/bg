using Core.Entities;
using Core.Enums;
using Core.ValueObjects.Common;
using Core.ValueObjects.TrainingPlan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlan>
{
    public void Configure(EntityTypeBuilder<TrainingPlan> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Duration)
            .HasConversion(e => e.Value, e => new Duration(e))
            .IsRequired()
            .HasMaxLength(Duration.MaxDuration);
        builder.Property(e => e.Price)
            .HasConversion(e => e.Value, e => new Price(e))
            .IsRequired();
        builder.Property(e => e.SkillLevel)
            .HasConversion(
                v => v.ToString(),
                v => (SkillLevel)Enum.Parse(typeof(SkillLevel), v));
        builder.Property(e => e.Title)
            .HasConversion(e => e.Value, e => new Title(e))
            .IsRequired()
            .HasMaxLength(Title.MaxLength);
        builder.Property(e => e.Description)
            .HasConversion(e => e.Value, e => new Description(e))
            .IsRequired()
            .HasMaxLength(Description.MaxLength);
        builder.Property(e => e.Description)
            .HasConversion(e => e.Value, e => new Description(e))
            .IsRequired()
            .HasMaxLength(Description.MaxLength);
        builder.Property(e => e.Status)
            .HasConversion(e => e.Value, e => new Status(e))
            .IsRequired();

        builder.HasOne(e => e.Author)
            .WithMany(e => e.CreatedTrainingPlans)
            .HasForeignKey(e => e.AuthorId);
    }
}