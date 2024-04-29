using DBGuard.Shared.DTO.CommitFile;
using DBGuard.Shared.DTO.SelectedItems;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.SqlService.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CommitFilesController : ControllerBase
{
    private readonly ICommitFilesService _commitFilesService;

    public CommitFilesController(ICommitFilesService commitFilesService)
    {
        _commitFilesService = commitFilesService;
    }

    [HttpPost]
    public async Task<ActionResult<ICollection<CommitFileDto>>> SaveAsync(SelectedItemsDto dto)
    {
        return Ok(await _commitFilesService.SaveSelectedFilesAsync(dto));
    }
}
