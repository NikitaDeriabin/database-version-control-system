﻿using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.Common.DTO.Branch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBGuard.Core.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet("{projectId}")]
    public ActionResult<List<BranchDto>> GetAllBranches(int projectId)
    {
        return Ok(_branchService.GetAllBranches(projectId));
    }

    [HttpGet("{projectId}/{sourceId}")]
    public async Task<ActionResult<List<BranchDetailsDto>>> GetAllBranchDetails(int projectId, int sourceId)
    {
        return Ok(await _branchService.GetAllBranchDetailsAsync(projectId, sourceId));
    }

    [HttpGet("lastcommit/{branchId}")]
    public async Task<ActionResult<int>> GetLastBranchCommit(int branchId)
    {
        return Ok(await _branchService.GetLastBranchCommitIdAsync(branchId));
    }

    [HttpPost("{projectId}")]
    public async Task<ActionResult<BranchDto>> AddBranchAsync(int projectId, [FromBody] BranchCreateDto dto) 
    { 
        return Ok(await _branchService.AddBranchAsync(projectId, dto));
    }

    [HttpPost("merge")]
    public async Task<ActionResult<BranchDto>> MergeBranch([FromBody] MergeBranchDto dto)
    {
        return Ok(await _branchService.MergeBranchAsync(dto.SourceId, dto.DestinationId));
    }

    [HttpPut("{branchId}")]
    public async Task<ActionResult<BranchDto>> UpdateBranchAsync(int branchId, [FromBody] BranchUpdateDto dto)
    {
        return Ok(await _branchService.UpdateBranchAsync(branchId, dto));
    }

    [HttpDelete("{branchId}")]
    public async Task<ActionResult> DeleteBranchAsync(int branchId)
    {
        await _branchService.DeleteBranchAsync(branchId);
        return NotFound();
    }
}
