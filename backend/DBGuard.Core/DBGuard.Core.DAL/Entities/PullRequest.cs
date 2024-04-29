using DBGuard.Core.DAL.Entities.Common.AuditEntity;
using DBGuard.Core.DAL.Entities.JoinEntities;
using DBGuard.Core.DAL.Enums;

namespace DBGuard.Core.DAL.Entities;

public sealed class PullRequest : AuditEntity<int>
{
    public string Title { get; set; } = string.Empty;
    public PullRequestStatus Status { get; set; }
    public bool IsReviewed { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public int ProjectId { get; set; }
    public int SourceBranchId { get; set; }
    public int TargetBranchId { get; set; }
    public Project Project { get; set; } = null!;
    public User Author { get; set; } = null!;
    public Branch SourceBranch { get; set; } = null!;
    public Branch TargetBranch { get; set; } = null!;
    public ICollection<User> Reviewers = new List<User>();
    public ICollection<PullRequestReviewer> PullRequestReviewers { get; set; } = new List<PullRequestReviewer>();
}
