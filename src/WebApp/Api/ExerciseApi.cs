using Application.Abstractions.Messaging.Command;
using Application.Abstractions.Messaging.Query;
using Application.Commands.Exercise;
using Application.DTO.Entities;
using Application.Queries.Exercise;

namespace WebApp.Api;

public static class ExerciseApi
{
    private const string Endpoint = "exercises";
    
    public static void UseExerciseApi(this WebApplication webApp)
    {
        webApp.MapPost($"{Endpoint}/create", async (ICommandHandler<CreateExerciseCommand> handler, CreateExerciseCommand command) =>
        {
            await handler.HandleAsync(command);
            Results.Ok("Exercise created successfully");
        }).RequireAuthorization();
        
        webApp.MapGet($"{Endpoint}", async (IQueryHandler<GetExercisesQuery,IEnumerable<ExerciseDto>> handler, GetExercisesQuery query) =>
        {
            var result = await handler.HandleAsync(query);
            Results.Ok(result);
        }).RequireAuthorization();
    }
    
    
}