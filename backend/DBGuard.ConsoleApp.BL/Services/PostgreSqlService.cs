using DBGuard.ConsoleApp.BL.Services.Abstract;
using DBGuard.ConsoleApp.Models;
using Npgsql;

namespace DBGuard.ConsoleApp.BL.Services;

public class PostgreSqlService : BaseDbService
{
    public PostgreSqlService(string connectionString) : base(connectionString)
    {
    }

    public override QueryResultTable ExecuteQuery(ParameterizedSqlCommand query)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        return ExecuteQueryFromConnectionInternal(connection, query);
    }

    public override async Task<QueryResultTable> ExecuteQueryAsync(ParameterizedSqlCommand query)
    {
        await using var connection = new NpgsqlConnection(ConnectionString);
        return await ExecuteQueryFromConnectionInternalAsync(connection, query);
    }
}
