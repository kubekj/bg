using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Configurations;

internal sealed class PostgresConfig
{
    public string ConnectionString { get; set; }
}