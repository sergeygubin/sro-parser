using SroParser.Application.UseCases.Scraper.Dto;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Application.Abstraction;

public interface ISroParser
{
    Task<List<SroMemberDto>> ParseNextPage();
}