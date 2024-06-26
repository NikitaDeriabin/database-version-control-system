﻿using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IDbQueryProvider
{
    ParameterizedSqlCommand GetTablesNamesQuery();

    ParameterizedSqlCommand GetStoredProceduresNamesQuery();
    ParameterizedSqlCommand GetStoredProcedureDefinitionQuery(string storedProcedureSchema, string storedProcedureName);

    ParameterizedSqlCommand GetFunctionsNamesQuery();
    ParameterizedSqlCommand GetFunctionDefinitionQuery(string functionSchema, string functionName);

    ParameterizedSqlCommand GetViewsNamesQuery();
    ParameterizedSqlCommand GetViewDefinitionQuery(string viewSchema, string viewName);

    ParameterizedSqlCommand GetTableStructureQuery(string schema, string table);
    ParameterizedSqlCommand GetTableChecksAndUniqueConstraintsQuery(string schema, string name);

    ParameterizedSqlCommand GetStoredProceduresWithDetailsQuery();
    ParameterizedSqlCommand GetFunctionsWithDetailsQuery();
    ParameterizedSqlCommand GetViewsWithDetailsQuery();

    ParameterizedSqlCommand GetUserDefinedTypesWithDefaultsAndRulesAndDefinitionQuery();
    ParameterizedSqlCommand GetUserDefinedTableTypesStructureQuery();
}
