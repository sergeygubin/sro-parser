using Infrastructure.Parser;
using Microsoft.Extensions.DependencyInjection;
using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Services;
using SroParser.Infrastructure.Scraper;
using SroParser.Infrastructure.Services;

namespace SroParser.Infrastructure;

public static class InfrastructureBindings
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<ISroMemberService, SroMemberService>();
        services.AddScoped<ISroMembersFetcher, SroMembersFetcher>();
        services.AddScoped<ISroScraper, SroScraper>();
        services.AddScoped<ISroParser, SroMembersParser>();
    }
}