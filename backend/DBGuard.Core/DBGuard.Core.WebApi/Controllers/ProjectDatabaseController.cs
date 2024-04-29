using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.Common.DTO.ProjectDatabase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public sealed class ProjectDatabaseController : ControllerBase
{
    private readonly IProjectDatabaseService _projectDatabaseService;

    public ProjectDatabaseController(IProjectDatabaseService projectDatabaseService)
    {
        _projectDatabaseService = projectDatabaseService;
    }

    [HttpPost]
    public async Task<ActionResult<DatabaseInfoDto>> AddNewProjectDatabaseAsync([FromBody] ProjectDatabaseDto databaseDto)
    {
        return Ok(await _projectDatabaseService.AddNewProjectDatabaseAsync(databaseDto));
    }

    [HttpGet("all/{projectId}")]
    public async Task<ActionResult<ICollection<ProjectDatabaseDto>>> GetAllProjectDatabasesAsync(int projectId)
    {
        return Ok(await _projectDatabaseService.GetAllProjectDbAsync(projectId));
    }
}