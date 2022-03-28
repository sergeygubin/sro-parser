using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SroParserDbContext>
{
    public SroParserDbContext CreateDbContext(string[] args)
    {
        var configuration = MigrationsExtensions.GetConfiguration();
        var optionsBuilder = new DbContextOptionsBuilder<SroParserDbContext>();
        optionsBuilder.ConfigureMigrationsConnection(configuration.GetConnectionString("DefaultConnection"));
            
        return new SroParserDbContext(optionsBuilder.Options);
    }
}