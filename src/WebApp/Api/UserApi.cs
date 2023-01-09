using Application.Abstractions.Messaging.Command;
using Application.Commands.User;
using Application.Security;

namespace WebApp.Api;

public static class UserApi
{
    private const string Endpoint = "users";
    public static void UseUserApi(this WebApplication webApp)
    {
        webApp.MapPost($"{Endpoint}/signup", async (ICommandHandler<SignUpCommand> handler,SignUpCommand command) =>
        {
            await handler.HandleAsync(command);
            return Results.Ok("Registration successful");
        });
        
        webApp.MapPost($"{Endpoint}/signin", async (ICommandHandler<SignInCommand> handler,SignInCommand command, ITokenStorage storage) =>
        {
            await handler.HandleAsync(command);
            var jwt = storage.Get();
            return Results.Ok(jwt);
        });
        
        // webApp.MapPut($"{Endpoint}/edit/{{userid:guid}}", async (Guid userid) =>
        // {
        //     
        // })
    }
}