using DBGuard.ConsoleApp.Models;
using DBGuard.Core.Common.DTO.Script;

namespace DBGuard.Core.BLL.Interfaces;

public interface IScriptService
{
    Task<ScriptDto> CreateScriptAsync(CreateScriptDto dto, int authorId);
    Task<ScriptDto> UpdateScriptAsync(ScriptDto dto, int editorId);
    Task<ICollection<ScriptDto>> GetAllScriptsAsync(int projectId);
    Task DeleteScriptAsync(int scriptId);
    Task<ScriptContentDto> GetFormattedSqlAsync(InboundScriptDto inboundScriptDto);
    Task<QueryResultTable> ExecuteSqlScriptAsync(InboundScriptDto inboundScriptDto);
}