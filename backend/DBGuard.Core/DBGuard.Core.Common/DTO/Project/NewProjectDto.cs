using DBGuard.Core.Common.DTO.Branch;

namespace DBGuard.Core.Common.DTO.Project;

public sealed class NewProjectDto
{
    public ProjectDto Project { get; set; } = null!;
    public BranchCreateDto DefaultBranch { get; set; } = null!;
}