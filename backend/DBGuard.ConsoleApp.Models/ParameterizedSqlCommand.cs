using System.Data.SqlClient;

namespace DBGuard.ConsoleApp.Models;

public record ParameterizedSqlCommand(string Body, ICollection<SqlParameter> Parameters);