﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using DBGuard.AzureBlobStorage.Models;
using Microsoft.Extensions.Options;

namespace DBGuard.Core.WebAPI.Extensions;

public static class ApplicationBuilderExtension
{
    public static void UseAvatarContainer(this IApplicationBuilder app)
    {
        var blobServiceClient = app.ApplicationServices.GetService<BlobServiceClient>();
        var blobStorageOptions = app.ApplicationServices.GetService<IOptions<BlobStorageOptions>>();

        var containerClient = blobServiceClient?.GetBlobContainerClient(blobStorageOptions?.Value.ImagesContainer);
        containerClient?.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
    }
}