using SroParser.Application.UseCases.Member.Dto;

namespace SroParser.Application.Abstraction.Services;

public interface IMemberService
{
    public Task<IEnumerable<MemberDto>> GetAllMembers();
}