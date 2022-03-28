using Infrastructure.Persistence;
using SroParser.Application.Abstraction.Repositories;
using SroParser.Domain.Entities;

namespace Infrastructure.Repositories;

public class SroMemberRepository : ISroMemberRepository
{
    private readonly SroParserDbContext _context;

    public SroMemberRepository(SroParserDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveRange(IEnumerable<SroMember> sroMembers)
    {
        foreach (var sroMember in sroMembers)
        {
            await Save(sroMember);
        }
    }

    public async Task Save(SroMember sroMember)
    {
        await _context.SroMembers.AddAsync(sroMember);
    }
}