using Microsoft.Extensions.DependencyInjection;
using SroParser.Application.UseCases.Scraper.Mapping;
using SroParser.Application.UseCases.SroMember.Mapping;

namespace SroParser.Application.UseCases;

public static class UseCasesBindings
{
    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ScrapedSroMemberDtoMapperProfile));
        services.AddAutoMapper(typeof(SroMemberMapperProfile));
    }
}