using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.Shared.DTO.Procedure;
using DBGuard.Shared.Enums;
using static DBGuard.SqlService.BLL.Extensions.MappingExtensions;


namespace DBGuard.SqlService.BLL.MappingProfiles;

public sealed class ProcedureProfile : Profile
{
    public ProcedureProfile()
    {
        CreateMap<QueryResultTable, ProcedureNamesDto>()!
            .ForMember(dest => dest.Procedures, opt
                => opt.MapFrom(src =>
                    src.Rows.Any()
                        ? src.Rows.Select(r => new Procedure { Name = r[1], Schema = r[0] })
                        : Enumerable.Empty<Procedure>()));

        CreateMap<QueryResultTable, ProcedureDetailsDto>()!
            .ForMember(dest => dest.Details, opt
                => opt.MapFrom(src =>
                    src.Rows.Any()
                        ? src.Rows.Select(row => MapToObject<ProcedureDetailInfo>(src.ColumnNames.Select(c => c.ToLower()).ToList(), row))
                        : Enumerable.Empty<ProcedureDetailInfo>()));

        CreateMap<Procedure, DatabaseItem>()!
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => DatabaseItemType.StoredProcedure));
    }
}