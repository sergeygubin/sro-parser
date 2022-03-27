using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using SroParser.Domain.Entities;

namespace Infrastructure.Persistence;

public class SroParserDbContext : DbContext
{
    public DbSet<SroMember> SroMembers { get; set; }
    
    public SroParserDbContext(DbContextOptions<SroParserDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        ApplyConfigurations(modelBuilder);
    }

    private static void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SroMemberConfiguration());
    }
}