using Core.Entities;
using Core.ValueObjects.Common;
using Core.ValueObjects.Workout;
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
        builder.Property(x => x.Category)
            .HasConversion(x => x.Value, x => new Category(x))
            .IsRequired();
    }
}