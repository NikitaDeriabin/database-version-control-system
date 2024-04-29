using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.BLL.Services.Abstract;
using DBGuard.Shared.DTO.DatabaseItem;
using Microsoft.Extensions.Configuration;

namespace DBGuard.Core.BLL.Services;

public class DatabaseItemsService : IDatabaseItemsService
{
    private const string DatabaseItemsRoutePrefix = "/api/DatabaseItems/";
    private readonly IHttpClientService _httpClientService;
    private readonly IConfiguration _configuration;

    public DatabaseItemsService(IHttpClientService httpClientService, IConfiguration configuration)
    {
        _httpClientService = httpClientService;
        _configuration = configuration;
    }

    public async Task<ICollection<DatabaseItem>> GetAllItemsAsync(Guid clientId)
    {
        return await _httpClientService.GetAsync<List<DatabaseItem>>
            ($"{_configuration[BaseService.SqlServiceUrlSection]}{DatabaseItemsRoutePrefix}{clientId}");
    }
}
