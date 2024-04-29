using DBGuard.SqlService.BLL.Hubs;

namespace DBGuard.SqlService.WebApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseConsoleAppHub(this WebApplication app)
    {
        var consoleAppHubName = "ConsoleAppHub";
        app.MapHub<ConsoleAppHub>(consoleAppHubName);
    }
}