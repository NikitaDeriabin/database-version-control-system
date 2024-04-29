using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.SqlService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class DatabaseItemsController : ControllerBase
{
    private readonly IDbItemsRetrievalService _dbItemsRetrieval;

    public DatabaseItemsController(IDbItemsRetrievalService dbItemsRetrieval)
    {
        _dbItemsRetrieval = dbItemsRetrieval;
    }

    [HttpGet("{clientId}")]
    public async Task<ActionResult<ICollection<DatabaseItem>>> GetAllItemsAsync(Guid clientId)
    {
        return Ok(await _dbItemsRetrieval.GetAllItemsAsync(clientId));
    }
}
