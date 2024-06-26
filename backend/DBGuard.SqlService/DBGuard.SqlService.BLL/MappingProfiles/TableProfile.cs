﻿using AutoMapper;
using DBGuard.ConsoleApp.Models;
using DBGuard.Shared.DTO;
using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.Shared.DTO.Table;
using DBGuard.Shared.Enums;
using static DBGuard.SqlService.BLL.Extensions.MappingExtensions;

namespace DBGuard.SqlService.BLL.MappingProfiles;

public sealed class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<QueryResultTable, TableNamesDto>()!
            .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Rows.Any()
                ? src.Rows.Select(row => new Table { Schema = row[0], Name = row[1] })
                : Enumerable.Empty<Table>()));

        CreateMap<QueryResultTable, TableStructureDto>()!
            .ForMember(dest => dest.Schema, opt => opt.MapFrom(src => src.Rows.Any() ? src.Rows[0][0] : null))!
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Rows.Any() ? src.Rows[0][1] : null))!
            .ForMember(dest => dest.Columns, opt => opt.MapFrom(src
                => src.Rows.Select(row => MapToObject<TableColumnInfo>(src.ColumnNames.Select(e => e.ToLower()).ToList(), row))));

        CreateMap<QueryResultTable, TableConstraintsDto>()!
            .ForMember(dest => dest.Constraints, opt => opt.MapFrom(src 
                => src.Rows.Select(row => MapToObject<Constraint>(src.ColumnNames.Select(e => e.ToLower()).ToList(), row))));

        CreateMap<Table, DatabaseItem>()!
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => DatabaseItemType.Table));
    }
}