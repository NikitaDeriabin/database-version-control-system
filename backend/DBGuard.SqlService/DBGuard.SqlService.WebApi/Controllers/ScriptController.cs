using DBGuard.Core.Common.DTO.Script;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.SqlService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ScriptController : ControllerBase
{
    private readonly ISqlFormatterService _sqlFormatterService;

    public ScriptController(ISqlFormatterService sqlFormatterService)
    {
        _sqlFormatterService = sqlFormatterService;
    }

    /// <summary>
    /// Find errors and format provided SQL script
    /// </summary>
    [HttpPut("format")]
    public ActionResult<ScriptContentDto> GetFormattedSql([FromBody] InboundScriptDto inboundScriptDto)
    {
        return Ok(_sqlFormatterService.GetFormattedSql(inboundScriptDto.DbEngine, inboundScriptDto.Content!));
    }
}