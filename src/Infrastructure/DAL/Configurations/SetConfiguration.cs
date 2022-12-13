using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class SetConfiguration : IEntityTypeConfiguration<Set>
{
    public void Configure(EntityTypeBuilder<Set> builder)
    {
        throw new NotImplementedException();
    }
}