using DBGuard.Core.Common.DTO.Script;
using DBGuard.Core.DAL.Enums;

namespace DBGuard.SqlService.BLL.Interfaces;

public interface ISqlFormatterService
{
    ScriptContentDto GetFormattedSql(DbEngine dbEngine, string inputSql);
}
