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
    private int _page = 0;
    
    private readonly HtmlWeb _web = new HtmlWeb();

    public void Configure(SroScraperParameters config)
    {
        _baseUrl = config.BaseUrl;
        _page = config.Page;
    }
    
    public Task<List<ScrappedSroMemberDto>> ScrapSroMembers()
    {
        try
        {
            return ScrapSroTable();
        }
        catch(Exception ex)
        {
            throw HandleException(ex);
        }
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

    private async Task<List<ScrappedSroMemberDto>> ScrapSroTable()
    {
        await GetTotalPages();
        var document = await _web.LoadFromWebAsync(ConfigureUrl());

        var rows = document.DocumentNode
            .SelectSingleNode("//table//tbody");

        if (rows == null)
        {
            throw new NothingToScrapException();
        }
        
        var scrappedMembers = new List<ScrappedSroMemberDto>();
        foreach (var row in rows.SelectNodes("//tr").Skip(2))
        {
            var items = new List<string>();
            foreach (HtmlNode cell in row.SelectNodes("th|td")) {
                items.Add(cell.InnerText);
            }

            var member = new ScrappedSroMemberDto(items[0], items[1], long.Parse(items[2]));
            scrappedMembers.Add(member);
        }

        return scrappedMembers;
    }

    private string ConfigureUrl()
    {
        return $"{_baseUrl}&page={_page}";
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