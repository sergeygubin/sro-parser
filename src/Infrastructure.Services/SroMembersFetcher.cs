using Microsoft.Extensions.Logging;
using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Infrastructure.Services;

public class SroMembersFetcher : ISroMembersFetcher
{
    private readonly ILogger<SroMembersFetcher> _logger;
    private readonly ISroParser _sroParser;

    public SroMembersFetcher(
        ILogger<SroMembersFetcher> logger,
        ISroParser sroParser)
    {
        _logger = logger;
        _sroParser = sroParser;
    }

    public async Task<List<SroMemberDto>> FetchAll()
    {
        var totalPages = await _sroParser.GetTotalPages();
        var sroMembers = new List<SroMemberDto>();
        _logger.LogInformation("Start parsing...");
        for (var page = 1; page <= totalPages; page++)
        {
            try
            {
                _logger.LogInformation($"Parse {page}/{totalPages} page");
                sroMembers.AddRange(await _sroParser.Parse(page));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to parse at {page} page. Details: {ex.Message}");
                break;
            }
        }
        
        _logger.LogInformation("Parsing is finished!");

        return sroMembers;
    }
}