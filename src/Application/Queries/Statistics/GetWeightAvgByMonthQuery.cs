using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;

namespace Application.Queries.Statistics;

public record GetWeightAvgByMonthQuery(Guid UserId) : IQuery<IDictionary<string,double>>;