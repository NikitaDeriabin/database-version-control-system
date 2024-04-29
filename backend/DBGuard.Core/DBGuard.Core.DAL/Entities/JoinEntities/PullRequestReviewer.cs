using DBGuard.Core.DAL.Entities.Common;

namespace DBGuard.Core.DAL.Entities.JoinEntities;

public sealed class PullRequestReviewer : Entity<int>
{
    public int PullRequestId { get; set; }
    public int UserId { get; set; }
    public PullRequest PullRequest { get; set; } = null!;
    public User User { get; set; } = null!;
}