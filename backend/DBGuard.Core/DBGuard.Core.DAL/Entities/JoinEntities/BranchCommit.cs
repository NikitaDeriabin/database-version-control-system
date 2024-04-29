using System.ComponentModel.DataAnnotations;
using DBGuard.Core.DAL.Entities.Common;

namespace DBGuard.Core.DAL.Entities.JoinEntities;

public sealed class BranchCommit : Entity<int>
{
    [Required]
    public bool IsMerged { get; set; }
    [Required]
    public bool IsHead { get; set; }
    
    public int BranchId { get; set; }
    public int CommitId { get; set; }
    public Branch Branch { get; set; } = null!;
    public Commit Commit { get; set; } = null!;
}