using AutoMapper;
using DBGuard.Core.BLL.MappingProfiles.MappingActions;
using DBGuard.Core.Common.DTO.Users;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>()!.AfterMap<BuildAvatarLinkAction>()!.ReverseMap();
        CreateMap<User, UserProfileDto>()!.AfterMap<BuildAvatarLinkAction>()!.ReverseMap();
    }
}