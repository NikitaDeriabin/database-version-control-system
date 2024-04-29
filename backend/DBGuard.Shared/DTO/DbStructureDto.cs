using DBGuard.Shared.DTO.Function;
using DBGuard.Shared.DTO.Procedure;
using DBGuard.Shared.DTO.Table;
using DBGuard.Shared.DTO.UserDefinedType.DataType;
using DBGuard.Shared.DTO.UserDefinedType.TableType;
using DBGuard.Shared.DTO.View;

namespace DBGuard.Shared.DTO;

public class DbStructureDto
{
    public List<TableStructureDto> DbTableStructures { get; set; } = new();
    public List<TableConstraintsDto> DbConstraints { get; set; } = new();

    public UserDefinedDataTypeDetailsDto DbUserDefinedDataTypeDetailsDto { get; set; } = new();
    public UserDefinedTables DbUserDefinedTableTypeDetailsDto { get; set; } = new();
    public FunctionDetailsDto DbFunctionDetails { get; set; } = new();
    public ProcedureDetailsDto DbProcedureDetails { get; set; } = new();
    public ViewDetailsDto DbViewsDetails { get; set; } = new();
}
