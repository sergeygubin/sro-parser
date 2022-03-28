using SroParser.Domain.Entities;

namespace SroParser.Application.Abstraction.Repositories;

public interface ISroMemberRepository
{
    public Task SaveRange(IEnumerable<SroMember> sroMembers);
    public Task Save(SroMember sroMember);
}