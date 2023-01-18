using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class GoalConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Value)
            .HasMaxLength(200)
            .IsRequired();
        builder.HasOne(e => e.User)
            .WithMany(e => e.Goals)
            .HasForeignKey(e => e.UserId);
    }
}