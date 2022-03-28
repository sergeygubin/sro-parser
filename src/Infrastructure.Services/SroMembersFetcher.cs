using AutoMapper;
using Microsoft.Extensions.Logging;
using SroParser.Application.Abstraction;
using SroParser.Application.Abstraction.Repositories;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.SroMember.Dto;
using SroParser.Domain.Entities;

namespace SroParser.Infrastructure.Services;

public class SroMembersFetcher : ISroMembersFetcher
{
    private readonly IMapper _mapper;
    private readonly ILogger<SroMembersFetcher> _logger;
    private readonly ISroParser _sroParser;
    private readonly ISroMemberRepository _repository;

    public SroMembersFetcher(
        IMapper mapper,
        ILogger<SroMembersFetcher> logger, 
        ISroParser sroParser,
        ISroMemberRepository repository)
    {
        _mapper = mapper;
        _logger = logger;
        _sroParser = sroParser;
        _repository = repository;
    }

    public async Task UpdateSroMembersFromRemote()
    {
        var totalPages = await _sroParser.GetTotalPages();
        _logger.LogInformation("Start parsing...");
        for (var page = 1; page <= totalPages; page++)
        {
            try
            {
                _logger.LogInformation($"Parse {page}/{totalPages} page");
                
                var sroMembersDto =  await _sroParser.Parse(page);
                var sroMembers = _mapper.Map<IEnumerable<SroMemberDto>, IEnumerable<SroMember>>(sroMembersDto);
                await _repository.SaveRange(sroMembers);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to parse at {page} page. Details: {ex.Message}");
                break;
            }
        }
        
        _logger.LogInformation("Parsing is finished!");
    }
}