using AutoMapper;
using DBGuard.Core.Common.DTO.Project;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>()!.ReverseMap();
        CreateMap<Project, UpdateProjectDto>()!.ReverseMap();
        CreateMap<Project, ProjectResponseDto>()!.ReverseMap();
    }
}