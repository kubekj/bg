using System.Globalization;
using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Core.Repositories;

namespace Application.Queries.Statistics.Handlers;

public class GetWeightAvgByMonthQueryHandler : IQueryHandler<GetWeightAvgByMonthQuery,IDictionary<string,double>>
{
    private readonly IMeasurementRepository _measurementRepository;

    public GetWeightAvgByMonthQueryHandler(IMeasurementRepository measurementRepository)
    {
        _measurementRepository = measurementRepository;
    }

    public async Task<IDictionary<string,double>> HandleAsync(GetWeightAvgByMonthQuery query)
    {
        var measurements = await _measurementRepository.GetAllMeasurementsAsync(x => x.UserId == query.UserId);
        var groupedMeasurements = measurements
            .GroupBy(m => m.DateProvided.ToString("MMMM", CultureInfo.InvariantCulture))
            .ToDictionary(g => g.Key, g => g.Average(m => m.Weight));

        return groupedMeasurements;
    }
}