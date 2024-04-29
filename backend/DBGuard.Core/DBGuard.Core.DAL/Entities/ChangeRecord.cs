using DBGuard.Core.DAL.Entities.Common.AuditEntity;

namespace DBGuard.Core.DAL.Entities;

public sealed class ChangeRecord : AuditEntity<int>
{
    public Guid UniqueChangeId { get; set; }

    public User? User { get; set; } = null!;
}
