using AutoMapper;
using DBGuard.Core.Common.DTO.Tag;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, TagDto>()!.ReverseMap();
    }
}