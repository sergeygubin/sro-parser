using Microsoft.EntityFrameworkCore;
using Migrations;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.ConnectToDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));

var contextFactory = new DesignTimeDbContextFactory();
var context = contextFactory.CreateDbContext(new string[] {});
if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}

var appliedMigrations = context.Database.GetAppliedMigrations().ToArray();
Console.WriteLine(string.Join("\n", appliedMigrations));

app.Run();