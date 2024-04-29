using DBGuard.Shared.Enums;

namespace DBGuard.Shared.DTO.DatabaseItem;

public sealed class DatabaseItem
{
    public string Name { get; set; } = null!;
    public DatabaseItemType Type { get; set; }
    public string Schema { get; set; } = null!;
}
