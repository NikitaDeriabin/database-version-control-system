using DBGuard.Core.DAL.Entities.Common;
using DBGuard.Core.DAL.Enums;

namespace DBGuard.Core.DAL.Entities;

public sealed class CommitFile : Entity<int>
{
    public string FileName { get; set; } = string.Empty;
    public FileType FileType { get; set; }
    public string BlobId { get; set; } = string.Empty;
    
    public int CommitId { get; set; }
    public Commit Commit { get; set; } = null!;
}
