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

    private async Task<List<ScrappedSroMemberDto>> ScrapSroTable()
    {
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
            var item = new List<string>();
            
            foreach (HtmlNode cell in row.SelectNodes("th|td")) {
                item.Add(cell.InnerText);
            }

            var member = new ScrappedSroMemberDto(
                item[0],
                item[1],
                item[2]
            );
            
            scrappedMembers.Add(member);
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