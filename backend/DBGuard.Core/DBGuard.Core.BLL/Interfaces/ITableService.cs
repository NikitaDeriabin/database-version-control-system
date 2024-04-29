using DBGuard.Shared.DTO.ConsoleAppHub;
using DBGuard.Shared.DTO.Table;

namespace DBGuard.Core.BLL.Interfaces;

public interface ITableService
{
    Task<TableNamesDto> GetTablesNameAsync(QueryParameters queryParameters);
}