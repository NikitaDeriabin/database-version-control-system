using Newtonsoft.Json;

namespace DBGuard.ConsoleApp.BL.Interfaces;

public interface IJsonSerializerSettingsService
{
    JsonSerializerSettings GetSettings();
}