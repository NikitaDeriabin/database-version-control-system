﻿using DBGuard.AzureBlobStorage.Models;

namespace DBGuard.AzureBlobStorage.Interfaces;

public interface IBlobStorageService
{
    Task UploadAsync(string containerName, Blob blob);
    Task UpdateAsync(string containerName, Blob blob);
    Task<Blob> DownloadAsync(string containerName, string blobId);
    Task<bool> DeleteAsync(string containerName, string blobId);
    Task CopyContainerAsync(string sourceContainerName, string destinationContainerName);
    Task<ICollection<Blob>> GetAllBlobsByContainerNameAsync(string containerName);
    Task<ICollection<string>> GetContainersByPrefixAsync(string prefix);
}