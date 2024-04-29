using AutoMapper;
using Azure.Storage.Blobs;
using DBGuard.AzureBlobStorage.Models;
using DBGuard.Core.Common.DTO.Users;
using DBGuard.Core.DAL.Entities;
using Microsoft.Extensions.Options;

namespace DBGuard.Core.BLL.MappingProfiles.MappingActions;

public class BuildAvatarLinkAction : IMappingAction<User, UserProfileDto>, IMappingAction<User, UserDto>
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobStorageOptions _blobStorageOptions;

    public BuildAvatarLinkAction(BlobServiceClient blobServiceClient, IOptions<BlobStorageOptions> blobStorageOptions)
    {
        _blobServiceClient = blobServiceClient;
        _blobStorageOptions = blobStorageOptions.Value;
    }

    public void Process(User source, UserProfileDto destination, ResolutionContext context)
    {
        destination.AvatarUrl = BuildLink(source.AvatarUrl);
    }

    public void Process(User source, UserDto destination, ResolutionContext context)
    {
        destination.AvatarUrl = BuildLink(source.AvatarUrl);
    }

    private string? BuildLink(string? avatarUrl)
    {
        return avatarUrl is not null
            ? $"{_blobServiceClient.Uri.AbsoluteUri}{_blobStorageOptions.ImagesContainer}/{avatarUrl}"
            : null;
    }
}
