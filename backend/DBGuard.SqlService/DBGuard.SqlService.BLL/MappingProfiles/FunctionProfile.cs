using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.Shared.DTO.Function;
using DBGuard.Shared.Enums;
using static DBGuard.SqlService.BLL.Extensions.MappingExtensions;

namespace DBGuard.SqlService.BLL.MappingProfiles;

public sealed class FunctionProfile : Profile
{
    public FunctionProfile()
    {
        CreateMap<QueryResultTable, FunctionNamesDto>()!
            .ForMember(dest => dest.Functions, opt
                => opt.MapFrom(src =>
                    src.Rows.Any()
                        ? src.Rows.Select(r => new Function { Name = r[1], Schema = r[0] })
                        : Enumerable.Empty<Function>()));

        CreateMap<QueryResultTable, FunctionDetailsDto>()!
            .ForMember(dest => dest.Details, opt
                => opt.MapFrom(src =>
                    src.Rows.Any()
                        ? src.Rows.Select(row => MapToObject<FunctionDetailInfo>(src.ColumnNames.Select(c => c.ToLower()).ToList(), row))
                        : Enumerable.Empty<FunctionDetailInfo>()));

        CreateMap<Function, DatabaseItem>()!
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => DatabaseItemType.Function));
    }
}