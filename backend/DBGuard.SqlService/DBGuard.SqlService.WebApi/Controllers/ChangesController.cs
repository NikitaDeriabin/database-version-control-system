using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.SqlService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ChangesController : ControllerBase
{
    private readonly IChangesLoaderService _changesLoaderService;

    public ChangesController(IChangesLoaderService changesLoaderService)
    {
        _changesLoaderService = changesLoaderService;
    }

    [HttpPost("{clientId}")]
    public async Task<IActionResult> SaveChangesToBlobAsync([FromBody] Guid changeId, Guid clientId)
    {
        await _changesLoaderService.LoadChangesToBlobAsync(changeId, clientId);

        return Ok();
    }
}
