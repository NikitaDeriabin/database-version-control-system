using DBGuard.ConsoleApp.BL.Exceptions;
using DBGuard.ConsoleApp.BL.Interfaces;
using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Services;

public class ConnectionService : IConnectionService
{
    private readonly IConnectionStringService _connectionStringService;
    private readonly IConnectionFileService _connectionFileService;
    private readonly IClientIdFileService _clientIdFileService;

    public ConnectionService(IConnectionStringService connectionStringService,
        IConnectionFileService connectionFileService, IClientIdFileService clientIdFileService)
    {
        _connectionStringService = connectionStringService;
        _connectionFileService = connectionFileService;
        _clientIdFileService = clientIdFileService;
    }

    public string TryConnect(ConnectionStringDto connectionStringDto)
    {
        var connectionString = _connectionStringService.BuildConnectionString(connectionStringDto);
        var databaseService =
            DatabaseServiceFactory.CreateDatabaseService(connectionStringDto.DbEngine, connectionString);
        var databaseProvider = DatabaseServiceFactory.CreateDbQueryProvider(connectionStringDto.DbEngine);

        // Test connection;
        try
        {
            var testQueryResult = databaseService.ExecuteQuery(databaseProvider.GetTablesNamesQuery());
            Console.WriteLine(testQueryResult);
            _connectionFileService.SaveToFile(connectionStringDto);
        }
        catch (Exception ex)
        {
            throw new DbConnectionFailed(connectionString, ex.Message);
        }

        return _clientIdFileService.GetClientId();
    }
}