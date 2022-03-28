using Domain.Abstraction;
using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.SroMember.Dto;
using SroParser.Infrastructure.Scraper;

namespace SroParser.Infrastructure.Services;

public class SroMemberService : ISroMemberService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISroMembersFetcher _fetcher;
    public SroMemberService(IUnitOfWork unitOfWork, ISroMembersFetcher sroMembersFetcher)
    {
        _unitOfWork = unitOfWork;
        _fetcher = sroMembersFetcher;
    }

    public async Task UpdateSroMembersFromRemote()
    {
        await _fetcher.FetchAllSroMembers();
    }
}