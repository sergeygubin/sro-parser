using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class InfrastructurePersistenceExtensions
{
    public static void ConnectToDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SroParserDbContext>(options =>
            ConfigureMigrationConnection(options, connectionString));
    }
    
    internal static void ConfigureMigrationConnection(this DbContextOptionsBuilder options, string connectionString)
    {
    }

    internal static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}