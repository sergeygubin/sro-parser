using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Migrations;

public static class MigrationsExtensions
{
    public static void ConnectToDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SroParserDbContext>(options =>
            ConfigureMigrationsConnection(options, connectionString));
    }

    internal static void ConfigureMigrationsConnection(this DbContextOptionsBuilder options, string connectionString)
    {
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11)), builder => builder.MigrationsAssembly("Migrations"));
    }

    internal static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}