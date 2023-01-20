using Core.Entities;
using Core.ValueObjects.Common;
using Core.ValueObjects.Exercise;
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
        builder.Property(x => x.BodyPart)
            .HasConversion(x => x.Value, x => new BodyPart(x))
            .IsRequired();
        builder.Property(x => x.Category)
            .HasConversion(x => x.Value, x => new Category(x))
            .IsRequired();
    }
}