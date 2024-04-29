using DBGuard.Shared.DTO.ConsoleAppHub;

namespace DBGuard.Core.BLL.Interfaces;

public interface IConsoleConnectService
{
    Task TryConnect(RemoteConnect remoteConnect);
}