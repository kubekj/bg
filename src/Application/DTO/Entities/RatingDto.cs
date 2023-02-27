using System;

namespace Application.DTO.Entities;

public record RatingDto(Guid TrainingPlanId, int Rate);