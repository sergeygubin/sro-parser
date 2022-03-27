using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Application.Abstraction.Services;

public interface ISroMembersFetcher
{
    Task<List<SroMemberDto>> FetchAll();
}