using Domain.Abstraction;
using Microsoft.Extensions.Logging;
using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.Scraper;
using SroParser.Application.UseCases.SroMember.Dto;
using SroParser.Infrastructure.Scraper;

namespace SroParser.Infrastructure.Services;

public class SroMemberService : ISroMemberService
{
    private readonly ILogger<SroMemberService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISroMembersFetcher _fetcher;
    public SroMemberService(
        IUnitOfWork unitOfWork, 
        ISroMembersFetcher sroMembersFetcher, 
        ILogger<SroMemberService> logger)
    {
        _unitOfWork = unitOfWork;
        _fetcher = sroMembersFetcher;
        _logger = logger;
    }

    public async Task UpdateSroMembersFromRemote()
    {
        await _fetcher.UpdateSroMembersFromRemote();

        _logger.LogInformation("Commiting to database...");
        
        try
        {
            await _unitOfWork.Commit();
        }
        catch(Exception ex)
        {
            _logger.LogError($"Failed to save. Details: {ex.Message}");
            
            return;
        }
        
        _logger.LogInformation("Successfully saved to database.");
    }
}