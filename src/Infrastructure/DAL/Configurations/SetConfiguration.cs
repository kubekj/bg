using Core.Entities;
using Core.ValueObjects.Properties.Set;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class SetConfiguration : IEntityTypeConfiguration<Set>
{
    public void Configure(EntityTypeBuilder<Set> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Weight)
            .HasConversion(e => e.Value, e => new Weight(e))
            .IsRequired()
            .HasMaxLength(Weight.MaxWeight);
        builder.Property(e => e.Repetitions)
            .HasConversion(e => e.Value, e => new Repetition(e))
            .IsRequired()
            .HasMaxLength(Repetition.MaxRepetition);

        builder.HasOne(e => e.Exercise)
            .WithMany(e => e.Sets)
            .HasForeignKey(e => e.ExerciseId);
    }
}