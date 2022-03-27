using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Infrastructure.Services;

public class SroMembersFetcher : ISroMembersFetcher
{
    private readonly ISroParser _sroParser;

    public SroMembersFetcher(ISroParser sroParser)
    {
        _sroParser = sroParser;
    }

    public async Task<List<SroMemberDto>> FetchAll()
    {
        // var sroMembers = new List<SroMemberDto>();
        // for (;;)
        // {
        //     try
        //     {
        //         sroMembers.AddRange(await _sroParser.ParseNextPage());
        //     }
        //     catch(Exception ex)
        //     {
        //         break;
        //     }
        // }

        return await _sroParser.ParseNextPage();
    }
}