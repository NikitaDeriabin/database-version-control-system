using DBGuard.Core.BLL.Interfaces;
using DBGuard.Shared.DTO.DatabaseItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommitChangesController : ControllerBase
{
    private readonly ICommitChangesService _commitChangesService;

    public CommitChangesController(ICommitChangesService commitChangesService)
    {
        _commitChangesService = commitChangesService;
    }
    
    [HttpGet("{commitId}/{tempBlobId}")]
    public async Task<ActionResult<List<DatabaseItemContentCompare>>> GetContentDiffsAsync(int commitId, Guid tempBlobId)
    {
        return Ok(await _commitChangesService.GetContentDiffsAsync(commitId, tempBlobId));
    }
}