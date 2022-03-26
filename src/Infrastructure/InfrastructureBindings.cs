using Microsoft.Extensions.DependencyInjection;
using SroParser.Application.Abstraction.Services;
using SroParser.Infrastructure.Services;

namespace SroParser.Infrastructure;

public static class InfrastructureBindings
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMemberService, MemberService>();
    }
}