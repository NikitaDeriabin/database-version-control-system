﻿using DBGuard.Core.Common.DTO.Branch;
using DBGuard.Core.DAL.Entities;
using DBGuard.Core.DAL.Entities.JoinEntities;

namespace DBGuard.Core.BLL.Interfaces;

public interface IBranchService
{
    Task<BranchDto> AddBranchAsync(int projectId, BranchCreateDto branchDto);
    BranchDto[] GetAllBranches(int projectId);
    Task<int> GetLastBranchCommitIdAsync(int branchId);
    Task<(BranchCommit?, bool)> FindHeadBranchCommitAsync(Branch branch);
    Task<BranchDto> UpdateBranchAsync(int branchId, BranchUpdateDto branchUpdateDto);
    Task DeleteBranchAsync(int branchId);
    Task<BranchDto> MergeBranchAsync(int sourceId, int destId);
    Task<ICollection<Commit>> GetCommitsFromBranchInternalAsync(int branchId, int destinationId);
    Task<ICollection<BranchDetailsDto>> GetAllBranchDetailsAsync(int projectId, int selectedBranch);
}