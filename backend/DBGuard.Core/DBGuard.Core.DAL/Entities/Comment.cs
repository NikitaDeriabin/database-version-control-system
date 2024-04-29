using DBGuard.Core.DAL.Entities.Common.AuditEntity;
using DBGuard.Core.DAL.Enums;

namespace DBGuard.Core.DAL.Entities;

public sealed class Comment : AuditEntity<int>
{
    public string Content { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
    public CommentedEntity CommentedEntity { get; set; }
    
    public int CommentedEntityId { get; set; }
    public User Author { get; set; } = null!;
}