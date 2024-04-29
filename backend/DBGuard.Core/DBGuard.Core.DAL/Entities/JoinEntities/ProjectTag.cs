using DBGuard.Core.DAL.Entities.Common;

namespace DBGuard.Core.DAL.Entities.JoinEntities;

public sealed class ProjectTag : Entity<int>
{
    public int TagId { get; set; }
    public int ProjectId { get; set; }
    public Tag Tag { get; set; } = null!;
    public Project Project { get; set; } = null!;
}