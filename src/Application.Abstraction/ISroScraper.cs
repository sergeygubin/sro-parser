using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.Scraper.Dto;

namespace SroParser.Application.Abstraction;

public interface ISroScraper
{
    void Configure(SroScraperParameters parameters);
    Task<List<ScrapedSroMemberDto>> ScrapSroMembers();
    Task<int> GetTotalPages();
}