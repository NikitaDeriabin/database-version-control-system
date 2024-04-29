using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IConnectionStringService
{
    string BuildConnectionString(ConnectionStringDto connectionStringDto);
}