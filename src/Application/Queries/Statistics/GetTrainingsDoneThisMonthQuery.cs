using System;
using Application.Abstractions.Messaging.Query;

namespace Application.Queries.Statistics;

public record GetTrainingsDoneThisMonthQuery(Guid UserId) : IQuery<Tuple<int,int>>;