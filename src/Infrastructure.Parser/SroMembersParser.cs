using AutoMapper;
using SroParser.Application.Abstraction;
using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.Scraper.Dto;
using SroParser.Application.UseCases.SroMember.Dto;

namespace Infrastructure.Parser;

public class SroMembersParser : ISroParser
{
    private int _currentPage = 1;

    private readonly IMapper _mapper;
    private readonly ISroScraper _sroScraper;

    public SroMembersParser(IMapper mapper, ISroScraper sroScraper)
    {
        _mapper = mapper;
        _sroScraper = sroScraper;

        ReconfigureScraper();
    }

    private void ReconfigureScraper()
    {
        _sroScraper.Configure(new SroScraperParameters
        {
            BaseUrl = "https://reestr.nostroy.ru/reestr",
            Page = _currentPage
        });
    }

    public async Task<List<SroMemberDto>> ParseNextPage()
    {
        var scrappedMembers = await _sroScraper.ScrapSroMembers();
        _currentPage++;
        ReconfigureScraper();
        
        return _mapper.Map<List<ScrappedSroMemberDto>, List<SroMemberDto>>(scrappedMembers);
    }
}