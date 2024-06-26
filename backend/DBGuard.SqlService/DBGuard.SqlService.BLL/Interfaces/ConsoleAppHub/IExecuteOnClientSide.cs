﻿using DBGuard.Shared.DTO.ConsoleAppHub;

namespace DBGuard.SqlService.BLL.Interfaces.ConsoleAppHub;

public interface IExecuteOnClientSide
{
    Task SetClientId(string guid);

    // Actions
    Task GetAllTablesNamesAsync(Guid queryId);
    Task GetAllStoredProceduresNamesAsync(Guid queryId);
    Task GetAllFunctionsNamesAsync(Guid queryId);

    Task GetStoredProcedureDefinitionAsync(Guid queryId, string schemaName, string storedProcedureName);
    
    Task GetFunctionDefinitionAsync(Guid queryId, string schemaName, string functionName);

    Task GetAllViewsNamesAsync(Guid queryId);
    Task GetViewDefinitionAsync(Guid queryId, string schemaName, string viewName);

    Task GetTableStructureAsync(Guid queryId, string schema, string tableName);
    Task GetTableChecksAndUniqueConstraintsAsync(Guid queryId, string schema, string tableName);

    Task GetStoredProceduresWithDetailAsync(Guid queryId);
    Task GetFunctionsWithDetailAsync(Guid queryId);
    Task GetViewsWithDetailAsync(Guid queryId);

    Task GetUserDefinedTypesWithDefaultsAndRulesAndDefinitionAsync(Guid queryId);
    Task GetUserDefinedTableTypesAsync(Guid queryId);
    Task RemoteConnectAsync(Guid queryId, ConnectionString connectionString);

    Task ExecuteScriptAsync(Guid queryId, string scriptContent);
}