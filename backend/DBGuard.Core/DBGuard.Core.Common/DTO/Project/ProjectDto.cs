using DBGuard.Core.DAL.Enums;

namespace DBGuard.Core.Common.DTO.Project;

public sealed class ProjectDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DbEngine DbEngine { get; set; }
}