using System.Linq.Expressions;
using Core.Entities;

namespace Core.Repositories;

public interface IMeasurementRepository
{
    public Task<Measurement> GetAllMeasurements(Expression<Func<Measurement, bool>>? expression = default);
    public Task AddAsync(Measurement measurement);
}