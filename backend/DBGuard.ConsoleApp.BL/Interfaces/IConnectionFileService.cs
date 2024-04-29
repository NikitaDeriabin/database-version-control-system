using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IConnectionFileService
{
    void CreateInitFile();
    ConnectionStringDto ReadFromFile();
    void SaveToFile(ConnectionStringDto connectionStringDto);
}