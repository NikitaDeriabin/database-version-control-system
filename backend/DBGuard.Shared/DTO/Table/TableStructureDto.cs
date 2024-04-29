namespace DBGuard.Shared.DTO.Table;

public class TableStructureDto : BaseDbItemWithDefinition
{
    public List<TableColumnInfo> Columns { get; set; } = new();
}