using DBGuard.Core.BLL.Interfaces;
using DBGuard.Shared.DTO.DatabaseItem;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class DatabaseItemsController : ControllerBase
{
    private readonly IDatabaseItemsService _databaseItemsService;

    public DatabaseItemsController(IDatabaseItemsService databaseItemsService)
    {
        _databaseItemsService = databaseItemsService;
    }

    [HttpGet("{clientId}")]
    public async Task<ActionResult<ICollection<DatabaseItem>>> GetAllDbItemsAsync(Guid clientId)
    {
        return Ok(await _databaseItemsService.GetAllItemsAsync(clientId));
    }
}

