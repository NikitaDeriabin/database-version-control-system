﻿using System.Data.SqlClient;
using DBGuard.ConsoleApp.BL.Interfaces;
using DBGuard.ConsoleApp.Models;
using Npgsql;

namespace DBGuard.ConsoleApp.BL.Services;

public sealed class ConnectionStringService : IConnectionStringService
{
    public string BuildConnectionString(ConnectionStringDto connectionStringDto)
    {
        return connectionStringDto.DbEngine switch
        {
            DbEngine.SqlServer => BuildSqlServerConnectionString(connectionStringDto),
            DbEngine.PostgreSql => BuildPostgresConnectionString(connectionStringDto),
            _ => string.Empty
        };
    }

    private string BuildSqlServerConnectionString(ConnectionStringDto connectionStringDto)
    {
        return new SqlConnectionStringBuilder
        {
            DataSource = connectionStringDto.ServerName,
            InitialCatalog = connectionStringDto.DbName,
            UserID = connectionStringDto.Username,
            Password = connectionStringDto.Password,
            IntegratedSecurity = connectionStringDto.IntegratedSecurity
        }.ConnectionString;
    }

    private string BuildPostgresConnectionString(ConnectionStringDto connectionStringDto)
    {
        return new NpgsqlConnectionStringBuilder
        {
            Host = connectionStringDto.ServerName,
            Port = connectionStringDto.Port,
            Database = connectionStringDto.DbName,
            Username = connectionStringDto.Username,
            Password = connectionStringDto.Password
        }.ConnectionString;
    }
}