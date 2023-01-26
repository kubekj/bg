using Core.Entities;
using Core.ValueObjects.Common;
using Core.ValueObjects.Language;
using Core.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x))
            .IsRequired()
            .HasMaxLength(Email.MaxLenght);
        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new FirstName(x))
            .IsRequired()
            .HasMaxLength(FirstName.MaxLength);
        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new LastName(x))
            .IsRequired()
            .HasMaxLength(LastName.MaxLength);
        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => new Password(x))
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Role)
            .HasConversion(x => x.Value, x => new Role(x))
            .IsRequired()
            .HasMaxLength(Role.MaxLenght);
        builder.Property(x => x.PreferredLanguage)
            .HasConversion(x => x.Value, x => new Language(x))
            .IsRequired()
            .HasMaxLength(Role.MaxLenght);
        builder.Property(x => x.Bio)
            .HasConversion(x => x.Value, x => new Description(x))
            .IsRequired()
            .HasMaxLength(Description.MaxLength);
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasMany(e => e.Goals)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
        builder.HasMany(e => e.Measurements)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
        builder.HasMany(e => e.Ratings)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
        builder.HasMany(e => e.CreatedTrainingPlans)
            .WithOne(e => e.Author)
            .HasForeignKey(e => e.AuthorId);
    }
}