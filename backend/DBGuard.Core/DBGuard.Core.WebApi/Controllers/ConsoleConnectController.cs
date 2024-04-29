using DBGuard.Core.BLL.Interfaces;
using DBGuard.Shared.DTO.ConsoleAppHub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ConsoleConnectController : ControllerBase
{
    private readonly IConsoleConnectService _consoleConnectService;

    public ConsoleConnectController(IConsoleConnectService consoleConnectService)
    {
        _consoleConnectService = consoleConnectService;
    }
    [HttpPost("db-connect")]
    public async Task<ActionResult> ConnectToDbAsync([FromBody] RemoteConnect remoteConnect)
    {
        await _consoleConnectService.TryConnect(remoteConnect);
        return Ok();
    }
}