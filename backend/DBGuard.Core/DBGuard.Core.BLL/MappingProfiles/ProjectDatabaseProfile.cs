using AutoMapper;
using DBGuard.Core.Common.DTO.ProjectDatabase;
using DBGuard.Core.DAL.Entities;

namespace DBGuard.Core.BLL.MappingProfiles;

public sealed class ProjectDatabaseProfile : Profile
{
    public ProjectDatabaseProfile()
    {
        CreateMap<ProjectDatabase, ProjectDatabaseDto>()!.ReverseMap();
        CreateMap<ProjectDatabase, DatabaseInfoDto>()!.ReverseMap();
    }
}