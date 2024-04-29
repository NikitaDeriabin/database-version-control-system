namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IClientIdFileService
{
    string GetClientId();
    void SetClientId(string guid);
}