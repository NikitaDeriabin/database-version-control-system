﻿using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.Common.DTO.Commit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommitController : ControllerBase
{
    private readonly ICommitService _commitService;

    public CommitController(ICommitService commitService)
    {
        _commitService = commitService;
    }

    [HttpPost]
    public async Task<ActionResult<CommitDto>> CreateCommitAsync(CreateCommitDto dto)
    {
        return Ok(await _commitService.CreateCommitAsync(dto));
    }
}
