using DBGuard.Shared.DTO;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.SqlService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyChangesController : ControllerBase
    {
        private readonly IApplyChangesService _applyChangesService;
        public ApplyChangesController(IApplyChangesService applyChangesService)
        {
            _applyChangesService = applyChangesService;
        }
        [HttpPost("{commitId}")]
        public async Task<ActionResult> ApplyChangesAsync([FromBody] ApplyChangesDto applyChangesDto, int commitId)
        {
            await _applyChangesService.ApplyChanges(applyChangesDto, commitId);
            return Ok();
        }
    }
}
