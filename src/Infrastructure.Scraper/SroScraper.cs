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

    private async Task<List<ScrappedSroMemberDto>> ScrapSroTable()
    {
        var document = await _web.LoadFromWebAsync(ConfigureUrl());

        var rows = document.DocumentNode
            .SelectSingleNode("//tbody")
            .SelectNodes("//tr")
            .Skip(2);
        
        if (rows == null)
        {
            throw new NothingToScrapException();
        }

        var scrappedMembers = new List<ScrappedSroMemberDto>();
        foreach (var row in rows)
        {
            var scrappedInfo = row.SelectNodes("//td")
                .Take(3)
                .Select(n => n.InnerText)
                .ToList();

            var test = row.SelectNodes("//td").Select(n => n.InnerText);

            scrappedMembers.Add(new ScrappedSroMemberDto(
                scrappedInfo[0], scrappedInfo[1], scrappedInfo[2])
            );
        }

        return scrappedMembers;
    }

    private string ConfigureUrl()
    {
        return "https://reestr.nostroy.ru/reestr?m.fulldescription=&m.shortdescription=&m.inn=&m.ogrnip=&bms.id=1&bmt.id=&u.registrationnumber=";
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