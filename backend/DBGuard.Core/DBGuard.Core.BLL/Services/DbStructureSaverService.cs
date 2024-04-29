using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.BLL.Services.Abstract;
using DBGuard.Core.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace DBGuard.Core.BLL.Services;

public class DbStructureSaverService : IDbStructureSaverService
{
    private const string ChangesRoutePrefix = "/api/Changes/";
    private readonly IHttpClientService _httpClientService;
    private readonly IConfiguration _configuration;

    public DbStructureSaverService(IHttpClientService httpClientService, IConfiguration configuration)
    {
        _httpClientService = httpClientService;
        _configuration = configuration;
    }

    public async Task SaveDbStructureToAzureBlobAsync(ChangeRecord changeRecord, Guid clientId)
    {
        await _httpClientService.SendAsync
            ($"{_configuration[BaseService.SqlServiceUrlSection]}{ChangesRoutePrefix}{clientId}", changeRecord.UniqueChangeId, HttpMethod.Post);
    }
}