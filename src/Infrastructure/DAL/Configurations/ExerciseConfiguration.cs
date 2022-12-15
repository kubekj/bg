using Core.Entities;
using Core.Enums;
using Core.ValueObjects.Properties.Exercise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new ExerciseName(x))
            .IsRequired()
            .HasMaxLength(ExerciseName.MaxLenght);
        builder.Property(e => e.BodyPart)
            .HasConversion(
                v => v.ToString(),
                v => (BodyPart)Enum.Parse(typeof(BodyPart), v))
            .IsRequired();
        builder.Property(e => e.Category)
            .HasConversion(
                v => v.ToString(),
                v => (Category)Enum.Parse(typeof(Category), v))
            .IsRequired();

        builder.HasMany(e => e.Sets)
            .WithOne(e => e.Exercise)
            .HasForeignKey(e => e.Id);
    }
}