using SroParser.Application.UseCases.Scraper.Dto;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Application.Abstraction;

public interface ISroParser
{
    Task<int> GetTotalPages();
    Task<List<SroMemberDto>> Parse(int page);
}