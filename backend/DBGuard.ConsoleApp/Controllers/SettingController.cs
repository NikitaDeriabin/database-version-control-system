using DBGuard.ConsoleApp.BL.Interfaces;
using DBGuard.ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.ConsoleApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SettingController : ControllerBase
{
    private readonly IConnectionService _connectionService;

    public SettingController(IConnectionService connectionService)
    {
        _connectionService = connectionService;
    }

    // http://localhost:44567/setting/connect
    [HttpPost("connect")]
    public IActionResult ConnectAsync(ConnectionStringDto connectionStringDto)
    {
        return Ok(_connectionService.TryConnect(connectionStringDto));
    }
}