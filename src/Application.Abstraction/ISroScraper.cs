using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.Scraper.Dto;

namespace SroParser.Application.Abstraction;

public interface ISroScraper
{
    void Configure(SroScraperParameters parameters);
    Task<int> GetTotalPages();
    Task<List<ScrapedSroMemberDto>> ScrapSroMembers(int page);
}