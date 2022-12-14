using Core.Entities;
using Core.Enums;
using Core.ValueObjects.Properties.Workout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .HasConversion(e => e.Value, e => new WorkoutName(e))
            .IsRequired()
            .HasMaxLength(WorkoutName.MaxLength);
        builder.Property(e => e.Category)
            .HasConversion(
                v => v.ToString(),
                v => (Category)Enum.Parse(typeof(Category), v))
            .IsRequired();
    }
}