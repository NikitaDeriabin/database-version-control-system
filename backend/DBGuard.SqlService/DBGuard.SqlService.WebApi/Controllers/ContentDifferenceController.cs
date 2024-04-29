using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.SqlService.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ContentDifferenceController : ControllerBase
{
    private readonly IContentDifferenceService _contentDifferenceService;

    public ContentDifferenceController(IContentDifferenceService contentDifference)
    {
        _contentDifferenceService = contentDifference;
    }

    [HttpGet("{commitId}/{tempBlobId}")]
    public async Task<ActionResult<ICollection<DatabaseItemContentCompare>>> GetContentDiffsAsync(int commitId, Guid tempBlobId)
    {
        return Ok(await _contentDifferenceService.GetContentDiffsAsync(commitId, tempBlobId));
    }
}
