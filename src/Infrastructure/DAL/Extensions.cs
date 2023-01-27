using Application.Abstractions.Messaging.Command;
using Core.Repositories;
using Infrastructure.DAL.DbUtils;
using Infrastructure.DAL.Decorators;
using Infrastructure.DAL.Repositories;
using Infrastructure.DAL.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DAL;

public static class Extensions
{
    private const string DatabaseName = "postgres";

    internal static void AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresConfig>(configuration.GetRequiredSection(DatabaseName));
        var postgresConfig = configuration.GetOptions<PostgresConfig>(DatabaseName);

        services.AddDbContext<BodyGuardDbContext>(x =>
            x.UseNpgsql(postgresConfig.ConnectionString));
        services.AddHostedService<DbInitializer>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        // EF Core + Npgsql issue
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    internal static void AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IUserExerciseRepository, UserExerciseRepository>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IExerciseWorkoutRepository, ExerciseWorkoutRepository>();
        services.AddScoped<IUserWorkoutRepository, UserWorkoutRepository>();
        services.AddScoped<IUserExerciseRepository, UserExerciseRepository>();
        services.AddScoped<ISetRepository, SetRepository>();
        services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
        services.AddScoped<IUserTrainingPlanRepository, UserTrainingPlanRepository>();
        services.AddScoped<ITrainingPlanWorkoutRepository, TrainingPlanWorkoutRepository>();
        services.AddScoped<IMeasurementRepository, MeasurementRepository>();
        services.AddScoped<IUserWorkoutSessionRepository, UserWorkoutSessionRepository>();
    }
}