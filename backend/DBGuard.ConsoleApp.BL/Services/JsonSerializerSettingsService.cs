using DBGuard.ConsoleApp.BL.Interfaces;
using Newtonsoft.Json;

namespace DBGuard.ConsoleApp.BL.Services;

public class JsonSerializerSettingsService : IJsonSerializerSettingsService
{
    public JsonSerializerSettings GetSettings()
    {
        var jsonSerializerSettings = new JsonSerializerSettings();
        jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        jsonSerializerSettings.Formatting = Formatting.Indented;

        return jsonSerializerSettings;
    }
}
