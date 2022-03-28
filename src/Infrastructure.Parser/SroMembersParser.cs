using AutoMapper;
using SroParser.Application.Abstraction;
using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.Scraper.Dto;
using SroParser.Application.UseCases.SroMember.Dto;

namespace Infrastructure.Parser;

public class SroMembersParser : ISroParser
{
    private readonly IMapper _mapper;
    private readonly ISroScraper _sroScraper;

    public SroMembersParser(IMapper mapper, ISroScraper sroScraper)
    {
        _mapper = mapper;
        _sroScraper = sroScraper;
        
        _sroScraper.Configure(new SroScraperParameters
        {
            BaseUrl = "https://reestr.nostroy.ru/reestr?m.fulldescription=&m.shortdescription=&m.inn=&m.ogrnip=&bms.id=1&bmt.id=&u.registrationnumber=",
        });
    }

    public async Task<int> GetTotalPages()
    {
        return await _sroScraper.GetTotalPages();
    }

    public async Task<List<SroMemberDto>> Parse(int page)
    {
        var scrapedMembers = await _sroScraper.ScrapSroMembers(page);
        
        return _mapper.Map<List<ScrapedSroMemberDto>, List<SroMemberDto>>(scrapedMembers);
    }
}