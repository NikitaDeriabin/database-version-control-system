using System.Text;
using DBGuard.AzureBlobStorage.Interfaces;
using DBGuard.AzureBlobStorage.Models;
using DBGuard.SqlService.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DBGuard.SqlService.BLL.Services;

public class ChangesLoaderService : IChangesLoaderService
{
    private const string UserDbChangesBlobContainerNameSection = "UserDbChangesBlobContainerName";
    private readonly IDbItemsRetrievalService _dbItemsRetrievalService;
    private readonly IBlobStorageService _blobStorageService;
    private readonly IConfiguration _configuration;

    public ChangesLoaderService(IDbItemsRetrievalService dbItemsRetrievalService, IBlobStorageService blobStorageService, IConfiguration configuration)
    {
        _dbItemsRetrievalService = dbItemsRetrievalService;
        _blobStorageService = blobStorageService;
        _configuration = configuration;
    }

    public async Task LoadChangesToBlobAsync(Guid changeId, Guid clientId)
    {
        var dbStructure = await _dbItemsRetrievalService.GetAllDbStructureAsync(clientId);
        var jsonString = JsonConvert.SerializeObject(dbStructure);
        var contentBytes = Encoding.UTF8.GetBytes(jsonString);
        var jsonMimeType = "application/json";

        var blob = new Blob
        {
            Id = changeId.ToString(),
            ContentType = jsonMimeType,
            Content = contentBytes
        };

        var containerName = _configuration[UserDbChangesBlobContainerNameSection];

        await _blobStorageService.UploadAsync(containerName, blob);
    }
}
