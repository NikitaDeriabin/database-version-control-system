using DBGuard.Shared.DTO.DatabaseItem;

namespace DBGuard.Core.BLL.Interfaces;

public interface IDatabaseItemsService
{
    Task<ICollection<DatabaseItem>> GetAllItemsAsync(Guid clientId);
}