namespace DBGuard.Shared.DTO;

public class BaseDbItemWithDefinition: BaseDbItem
{
    public string Definition { get; set; } = string.Empty;
}
