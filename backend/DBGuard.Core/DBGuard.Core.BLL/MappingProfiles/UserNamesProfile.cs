using AutoMapper;
using DBGuard.Core.Common.DTO.Users;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class UserNamesProfile : Profile
{
    public UserNamesProfile()
    {
        CreateMap<User, UpdateUserNamesDto>()!.ReverseMap();
    }
}