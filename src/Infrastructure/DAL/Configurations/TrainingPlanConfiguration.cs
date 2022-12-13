using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlan>
{
    public void Configure(EntityTypeBuilder<TrainingPlan> builder)
    {
        throw new NotImplementedException();
    }
}