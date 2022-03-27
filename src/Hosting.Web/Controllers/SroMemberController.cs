using Microsoft.AspNetCore.Mvc;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Hosting.Web.Controllers;

[ApiController]
[Route("api")]
[Produces("application/json")]
public class SroMemberController
{
    private readonly ISroMemberService _sroMemberService;
    
    public SroMemberController(ISroMemberService sroMemberService)
    {
        _sroMemberService = sroMemberService;
    }

    /// <summary>
    /// Получает и сохраняет всех текущих членов СРО из https://reestr.nostroy.ru/reestr
    /// </summary>
    /// <returns></returns>
    [HttpGet("update-sro-members")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task UpdateSroMembers()
    {
        await _sroMemberService.UpdateSroMembersFromRemote();
    }
}