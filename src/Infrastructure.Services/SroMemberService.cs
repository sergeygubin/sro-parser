using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.SroMember.Dto;
using SroParser.Infrastructure.Scraper;

namespace SroParser.Infrastructure.Services;

public class SroMemberService : ISroMemberService
{
    private readonly ISroMembersFetcher _fetcher;
    public SroMemberService(ISroMembersFetcher sroMembersFetcher)
    {
        _fetcher = sroMembersFetcher;
    }

    public async Task<List<SroMemberDto>> Update()
    {
        return await _fetcher.FetchAll();
    }

    public async Task<IEnumerable<SroMemberDto>> GetAllMembers()
    {
        var members = new List<SroMemberDto>
        {
            new SroMemberDto
            {
                Id = 1
            }
        };

        return members;
    }
}