using DBGuard.Shared.DTO;
using DBGuard.Shared.DTO.DatabaseItem;
using DBGuard.Shared.DTO.Function;
using DBGuard.Shared.DTO.Procedure;
using DBGuard.Shared.DTO.Table;
using DBGuard.Shared.DTO.UserDefinedType.DataType;
using DBGuard.Shared.DTO.UserDefinedType.TableType;
using DBGuard.Shared.DTO.View;

namespace DBGuard.SqlService.BLL.Interfaces;

public interface IDbItemsRetrievalService
{
    Task<ICollection<DatabaseItem>> GetAllItemsAsync(Guid clientId);

    Task<DbStructureDto> GetAllDbStructureAsync(Guid clientId);

    Task<TableNamesDto> GetTableNamesAsync(Guid clientId);

    Task<ICollection<TableStructureDto>> GetAllTableStructuresAsync(Guid clientId);

    Task<ICollection<TableConstraintsDto>> GetAllTableConstraintsAsync(Guid clientId);

    Task<FunctionNamesDto> GetFunctionsNamesAsync(Guid clientId);

    Task<FunctionDetailsDto> GetAllFunctionDetailsAsync(Guid clientId);

    Task<ProcedureNamesDto> GetProceduresNamesAsync(Guid clientId);

    Task<ProcedureDetailsDto> GetAllProcedureDetailsAsync(Guid clientId);

    Task<ViewNamesDto> GetViewNamesAsync(Guid clientId);

    Task<ViewDetailsDto> GetAllViewDetailsAsync(Guid clientId);

    Task<UserDefinedDataTypeDetailsDto> GetAllUdtDataTypeDetails(Guid clientId);

    Task<UserDefinedTables> GetAllUdtTableTypeDetails(Guid clientId);
}

