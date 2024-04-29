using System.Data.SqlClient;
using DBGuard.ConsoleApp.BL.Services.Abstract;
using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Services;

public class SqlServerService : BaseDbService
{
    public SqlServerService(string connectionString) : base(connectionString)
    {
    }

    public override QueryResultTable ExecuteQuery(ParameterizedSqlCommand query)
    {
        using var connection = new SqlConnection(ConnectionString);
        return ExecuteQueryFromConnectionInternal(connection, query);
    }

    public override async Task<QueryResultTable> ExecuteQueryAsync(ParameterizedSqlCommand query)
    {
        await using var connection = new SqlConnection(ConnectionString);
        return await ExecuteQueryFromConnectionInternalAsync(connection, query);
    }
}
