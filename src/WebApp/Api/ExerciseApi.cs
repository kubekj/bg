using Application.Abstractions.Messaging.Command;
using Application.Commands.Exercise;

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
    }
}