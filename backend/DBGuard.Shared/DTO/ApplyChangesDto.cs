using DBGuard.Core.DAL.Enums;

namespace DBGuard.Shared.DTO;

public class ApplyChangesDto
{
    public string? ClientId { get; set; }
    public DbEngine DbEngine { get; set; }
}