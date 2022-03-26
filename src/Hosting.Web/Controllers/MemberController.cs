using Microsoft.AspNetCore.Mvc;
using SroParser.Application.Abstraction.Services;
using SroParser.Application.UseCases.Member.Dto;

namespace SroParser.Hosting.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MemberController
{
    private readonly IMemberService _memberService;
    
    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    /// <summary>
    /// Возвращает всех членов СРО
    /// </summary>
    /// <returns></returns>
    [HttpGet("current")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IEnumerable<MemberDto>> GetAllMembers()
    {
        return await _memberService.GetAllMembers();
    }
}