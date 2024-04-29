using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IDatabaseService
{
    string ConnectionString { get; }
    QueryResultTable ExecuteQuery(ParameterizedSqlCommand query);
    Task<QueryResultTable> ExecuteQueryAsync(ParameterizedSqlCommand query);
}
