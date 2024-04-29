using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Shared.DTO.Definition;

namespace DBGuard.SqlService.BLL.MappingProfiles;

public sealed class RoutineProfile : Profile
{
    public RoutineProfile()
    {
        CreateMap<QueryResultTable, RoutineDefinitionDto>()!
            .ForMember(dest => dest.Definition, opt
                => opt.MapFrom(src =>
                    src.Rows.Any()
                        ? src.Rows[0][0]
                        : string.Empty));
    }
}