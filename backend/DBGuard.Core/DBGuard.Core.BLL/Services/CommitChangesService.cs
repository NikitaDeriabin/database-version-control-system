using AutoMapper;
using DBGuard.Core.BLL.Interfaces;
using DBGuard.Core.BLL.Services.Abstract;
using DBGuard.Core.DAL.Context;
using DBGuard.Shared.DTO.DatabaseItem;
using Microsoft.Extensions.Configuration;

namespace DBGuard.Core.BLL.Services;

public sealed class CommitChangesService: BaseService, ICommitChangesService
{
    private const string ChangesRoutePrefix = "/api/ContentDifference/";
    private readonly IHttpClientService _httpClientService;
    private readonly IConfiguration _configuration;

    public CommitChangesService(DbGuardCoreContext context, IMapper mapper, IHttpClientService httpClientService, IConfiguration configuration)
        : base(context, mapper)
    {
        _httpClientService = httpClientService;
        _configuration = configuration;
    }
    
    public async Task<List<DatabaseItemContentCompare>> GetContentDiffsAsync(int commitId, Guid tempBlobId)
    {
        return await _httpClientService.GetAsync<List<DatabaseItemContentCompare>>(
            $"{_configuration[SqlServiceUrlSection]}{ChangesRoutePrefix}{commitId}/{tempBlobId}");
    }
}