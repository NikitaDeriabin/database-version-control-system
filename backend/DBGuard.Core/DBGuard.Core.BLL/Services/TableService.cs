using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.BLL.Services.Abstract;
using DBGuard.Shared.DTO.ConsoleAppHub;
using DBGuard.Shared.DTO.Table;
using Microsoft.Extensions.Configuration;

namespace DBGuard.Core.BLL.Services;

public class TableService : ITableService
{
    private const string AllTableNamesRoutePrefix = "/api/ConsoleAppHub/all-tables-names";
    private readonly IHttpClientService _httpClientService;
    private readonly IConfiguration _configuration;

    public TableService(IHttpClientService httpClientService, IConfiguration configuration)
    {
        _httpClientService = httpClientService;
        _configuration = configuration;
    }

    public async Task<TableNamesDto> GetTablesNameAsync(QueryParameters queryParameters)
    {
        return await _httpClientService.SendAsync<QueryParameters, TableNamesDto>(
            $"{_configuration[BaseService.SqlServiceUrlSection]}{AllTableNamesRoutePrefix}", queryParameters, HttpMethod.Post);
    }
}