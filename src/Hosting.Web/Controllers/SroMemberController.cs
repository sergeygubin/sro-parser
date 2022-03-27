using Microsoft.AspNetCore.Mvc;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Hosting.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SroMemberController
{
    private readonly ISroMemberService _sroMemberService;
    
    public SroMemberController(ISroMemberService sroMemberService)
    {
        _sroMemberService = sroMemberService;
    }

    /// <summary>
    /// Возвращает всех членов СРО
    /// </summary>
    /// <returns></returns>
    [HttpGet("current")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IEnumerable<SroMemberDto>> GetAllMembers()
    {
        return await _sroMemberService.GetAllMembers();
    }
    
    /// <summary>
    /// Получает и сохраняет всех текущих членов СРО
    /// </summary>
    /// <returns></returns>
    [HttpGet("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IEnumerable<SroMemberDto>> UpdateSroMembers()
    {
        return await _sroMemberService.Update();
    }
}