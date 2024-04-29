using DBGuard.Core.Common.DTO.Branch;
using DBGuard.Core.Common.DTO.Users;
using DBGuard.Shared.DTO.CommitFile;

namespace DBGuard.Core.Common.DTO.Commit;
public class CommitDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public UserDto Author { get; set; } = null!;
    public ICollection<BranchDto> Branches = new List<BranchDto>();
    public ICollection<CommitFileDto> CommitFiles { get; set; } = new List<CommitFileDto>();
    public string PreScript { get; set; } = null!;
    public string PostScript { get; set; } = null!;
}
