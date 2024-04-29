using System.Text;
using DBGuard.Shared.DTO.Table;

namespace DBGuard.SqlService.BLL.Interfaces;

public interface ICreateTableScriptService
{
    string GenerateCreateTableScript(string tableSchema, string tableName, TableStructureDto tableStructure, List<string> fkConstraintScripts);
    string ConcatForeignKeysConstraintScripts(StringBuilder createScript, List<string> fkConstraintScripts);
}