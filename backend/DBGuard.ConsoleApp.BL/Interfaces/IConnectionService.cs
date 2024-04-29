using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IConnectionService
{
    string TryConnect(ConnectionStringDto connectionStringDto);
}