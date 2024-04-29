using DBGuard.Shared.DTO.Text;
using DBGuard.Shared.Enums;

namespace DBGuard.Shared.DTO.DatabaseItem;

public sealed class DatabaseItemContentCompare
{
    public string SchemaName { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    
    public DatabaseItemType ItemType { get; set; }
    
    public SideBySideDiffResultDto? SideBySideDiff { get; set; }
    public InLineDiffResultDto? InLineDiff { get; set; }
}