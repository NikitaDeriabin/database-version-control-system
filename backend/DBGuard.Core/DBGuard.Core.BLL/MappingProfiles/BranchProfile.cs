using AutoMapper;
using DBGuard.Core.Common.DTO.Branch;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class BranchProfile : Profile
{
    public BranchProfile()
    {
        CreateMap<Branch, BranchDto>()!.ReverseMap();
        CreateMap<Branch, BranchCreateDto>()!.ReverseMap();
        CreateMap<Branch, BranchDetailsDto>()
            .ForMember(x => x.LastUpdatedBy, s => s.MapFrom(x => x.Author))
            .ForMember(x => x.UpdatedAt, s => s.MapFrom(x => x.CreatedAt));
    }
}