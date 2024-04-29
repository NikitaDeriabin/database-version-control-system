using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.Shared.DTO.UserDefinedType.DataType;
using DBGuard.Shared.DTO.UserDefinedType.TableType;
using DBGuard.Shared.Enums;
using static DBGuard.SqlService.BLL.Extensions.MappingExtensions;

namespace DBGuard.SqlService.BLL.MappingProfiles;

public class UserDefinedTypeProfile: Profile
{
    public UserDefinedTypeProfile()
    {
        CreateMap<QueryResultTable, UserDefinedDataTypeDetailsDto>()
            .ForMember(dest => dest.Details, opt 
                => opt.MapFrom(src => 
                    src.Rows.Any()
                    ? src.Rows.Select(row => MapToObject<UserDefinedDataTypeDetailInfo>(src.ColumnNames.Select(c => c.ToLower()).ToList(), row))
                    : Enumerable.Empty<UserDefinedDataTypeDetailInfo>()));

        CreateMap<UserDefinedDataType, DatabaseItem>()
            .ForMember(dest => dest.Type, opt 
                => opt.MapFrom(src => DatabaseItemType.UserDefinedDataType));

        CreateMap<QueryResultTable, UserDefinedTables>()
            .ForMember(dest => dest.Tables, opt
                => opt.MapFrom(src
                    => src.Rows.Any()
                        ? MapToUdtTables(src.ColumnNames.Select(c => c.ToLower()).ToList(), src.Rows)
                        : Enumerable.Empty<UserDefinedTableDetailsDto>()));
        
        CreateMap<UserDefinedTableType, DatabaseItem>()
            .ForMember(dest => dest.Type, opt 
                => opt.MapFrom(src => DatabaseItemType.UserDefinedTableType));
    }
}