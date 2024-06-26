﻿using DBGuard.ConsoleApp.BL.Interfaces;

namespace DBGuard.ConsoleApp.BL.Services;

public class ClientIdFileService : IClientIdFileService
{
    private static string ClientIdFilePath => FilePathHelperService.GetClientIdFilePath();

    public string GetClientId()
    {
        var filePath = ClientIdFilePath;
        if (!File.Exists(filePath))
        {
            return string.Empty;
        }

        var guid = File.ReadAllText(filePath);
        return guid;
    }

    public void SetClientId(string guid)
    {
        File.WriteAllText(ClientIdFilePath, guid);
    }
}