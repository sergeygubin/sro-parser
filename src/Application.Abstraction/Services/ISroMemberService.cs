using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Application.Abstraction.Services;

public interface ISroMemberService
{
    Task UpdateSroMembersFromRemote();
}