using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IMeasurementRepository
{
    public Task<IEnumerable<Measurement>> GetAllMeasurementsAsync(Expression<Func<Measurement, bool>>? expression = default);
    public Task<Measurement?> GetForUserAsync(Guid userId);
    public Task AddAsync(Measurement measurement);
}