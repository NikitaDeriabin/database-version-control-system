using DBGuard.Core.Common.DTO.Users;

namespace DBGuard.Core.Common.DTO.Branch;
public class BranchDetailsDto: BranchDto
{
    public UserDto? LastUpdatedBy { get; set; } = null!;
    public int Ahead { get; set; }
    public int Behind { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = null!;
}
