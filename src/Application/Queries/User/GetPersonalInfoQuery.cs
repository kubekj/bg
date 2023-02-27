using System;
using Application.Abstractions.Messaging.Query;
using Application.DTO.Entities;

namespace Application.Queries.User;

public record GetPersonalInfoQuery(Guid UserId) : IQuery<UserDto>;