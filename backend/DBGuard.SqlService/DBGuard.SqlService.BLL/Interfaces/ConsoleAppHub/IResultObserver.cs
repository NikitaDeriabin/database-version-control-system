using DBGuard.ConsoleApp.Models;

namespace DBGuard.SqlService.BLL.Interfaces.ConsoleAppHub;

public interface IResultObserver
{
    public TaskCompletionSource<QueryResultTable> Register(Guid queryId);

    public void SetResult(Guid queryId, QueryResultTable queryResultTableDto);
}