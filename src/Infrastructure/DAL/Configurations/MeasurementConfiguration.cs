using Core.Entities;
using Core.ValueObjects.Measurement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class MeasurementConfiguration : IEntityTypeConfiguration<Measurement>
{
    public void Configure(EntityTypeBuilder<Measurement> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Weight)
            .HasConversion(e => e.Value, e => new BodyWeight(e))
            .IsRequired()
            .HasMaxLength(BodyWeight.MaxWeight);
        builder.Property(e => e.Height)
            .HasConversion(e => e.Value, e => new BodyHeight(e))
            .IsRequired()
            .HasMaxLength(BodyHeight.MaxHeight);
        builder.Property(e => e.CaloriesIntake)
            .HasConversion(e => e.Value, e => new CaloriesIntake(e))
            .IsRequired()
            .HasMaxLength(BodyHeight.MaxHeight);
        builder.Property(e => e.DateProvided).IsRequired();
        
        builder.HasOne(e => e.User)
            .WithMany(e => e.Measurements)
            .HasForeignKey(e => e.UserId);
    }
}