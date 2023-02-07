using System.Linq.Expressions;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

internal sealed class MeasurementRepository : IMeasurementRepository
{
    private readonly DbSet<Measurement> _measurements;

    public MeasurementRepository(BodyGuardDbContext context) => _measurements = context.Measurements;


    public async Task<IEnumerable<Measurement>> GetAllMeasurementsAsync(Expression<Func<Measurement, bool>> expression = default)
    {
        if (expression is not null)
            return await _measurements.Where(expression).ToListAsync();
        
        return await _measurements.ToListAsync();
    }

    public async Task<Measurement?> GetForUserAsync(Guid userId) 
        => await _measurements
            .Where(m => m.UserId == userId)
            .OrderByDescending(m => m.DateProvided)
            .FirstOrDefaultAsync();

    public async Task AddAsync(Measurement measurement) => await _measurements.AddAsync(measurement);
}