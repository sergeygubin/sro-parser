using Domain.Abstraction;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly SroParserDbContext _context;

    public UnitOfWork(SroParserDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}