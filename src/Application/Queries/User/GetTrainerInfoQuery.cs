using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.User;

public record GetTrainerInfoQuery(string Email) : IQuery<TrainerDto>;