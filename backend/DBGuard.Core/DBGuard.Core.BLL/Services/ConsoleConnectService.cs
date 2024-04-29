using DBGuard.Core.BLL.Interfaces;
using DBGuard.Shared.DTO.ConsoleAppHub;
using Microsoft.Extensions.Configuration;

namespace DBGuard.Core.BLL.Services;

public class ConsoleConnectService : IConsoleConnectService
{
    private readonly IHttpClientService _httpClientService;
    private readonly IConfiguration _configuration;

    public ConsoleConnectService(IHttpClientService httpClientService, IConfiguration configuration)
    {
        _httpClientService = httpClientService;
        _configuration = configuration;
    }

    public async Task TryConnect(RemoteConnect remoteConnect)
    {
        await _httpClientService.SendAsync($"{_configuration["SqlServiceUrl"]}/api/ConsoleAppHub/db-connect",
            remoteConnect, HttpMethod.Post);
    }
}