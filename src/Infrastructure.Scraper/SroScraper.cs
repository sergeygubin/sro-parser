using System.Runtime.InteropServices.ComTypes;
using HtmlAgilityPack;
using SroParser.Application.Abstraction;
using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.Scraper.Dto;
using SroParser.Application.UseCases.Scraper.Exceptions;

namespace SroParser.Infrastructure.Scraper;

public class SroScraper : ISroScraper
{
    private string _baseUrl = "";
    
    private readonly HtmlWeb _web = new();

    public void Configure(SroScraperParameters config)
    {
        _baseUrl = config.BaseUrl;
    }

    public async Task<int> GetTotalPages()
    {
        var document = await _web.LoadFromWebAsync(_baseUrl);
        var totalPages = document.DocumentNode.SelectNodes("//ul[@class='pagination']//a")
            .Select(n => n.InnerText)
            .Skip(4)
            .First();

        return int.Parse(totalPages);
    }
    
    public Task<List<ScrapedSroMemberDto>> ScrapSroMembers(int page)
    {
        try
        {
            return ScrapSroTable(page);
        }
        catch(Exception ex)
        {
            throw HandleException(ex);
        }
    }

    private async Task<List<ScrapedSroMemberDto>> ScrapSroTable(int page)
    {
        await GetTotalPages();
        var document = await _web.LoadFromWebAsync(ConfigureUrl(page));

        var rows = document.DocumentNode
            .SelectSingleNode("//table//tbody");

        if (rows == null)
        {
            throw new NothingToScrapException();
        }
        
        var scrapedMembers = new List<ScrapedSroMemberDto>();
        foreach (var row in rows.SelectNodes("//tr").Skip(2))
        {
            var items = new List<string>();
            foreach (HtmlNode cell in row.SelectNodes("th|td")) {
                items.Add(cell.InnerText);
            }

            var member = new ScrapedSroMemberDto(items[0], items[1], long.Parse(items[2]));
            scrapedMembers.Add(member);
        }

        return scrapedMembers;
    }

    private string ConfigureUrl(int page)
    {
        return $"{_baseUrl}&page={page}";
    }

    private static Exception HandleException(Exception ex)
    {
        throw ex switch
        {
            ScraperException => ex,
            _ => new FailedToScrapException(ex.Message)
        };
    }
}