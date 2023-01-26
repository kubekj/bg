using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class MeasurementRepository : IMeasurementRepository
{
    private readonly DbSet<Measurement> _measurements;

    public MeasurementRepository(BodyGuardDbContext context) => _measurements = context.Measurements;

    public Task<Measurement> GetAllMeasurements(Expression<Func<Measurement, bool>> expression = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Measurement measurement) => await _measurements.AddAsync(measurement);
}