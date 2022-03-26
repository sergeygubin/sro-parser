using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.Member.Dto;

namespace SroParser.Infrastructure.Services;

public class MemberService : IMemberService
{
    public async Task<IEnumerable<MemberDto>> GetAllMembers()
    {
        var members = new List<MemberDto>
        {
            new MemberDto
            {
                Id = 1
            }
        };
        
        return members;
    }
}