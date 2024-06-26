﻿using Microsoft.AspNetCore.Mvc;
using OperatingSystem = DBGuard.Core.Common.Models.OperatingSystem;

namespace DBGuard.Core.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StaticFilesController : Controller
{
    private const string ConsoleSetupFilePathSection = "ConsoleSetupFilePath";
    private const string OctetStreamMimeTypeName = "application/octet-stream";
    private const string WindowsConsoleSetupFileName = "SquirrelSetup.exe";
    private const string MacOSConsoleSetupFileName = "SquirrelSetup-osx-x64.zip";
    private readonly IConfiguration _configuration;

    public StaticFilesController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpGet("squirrel-installer/{operatingSystem}"), DisableRequestSizeLimit]
    public async Task<IActionResult> DownloadDbGuardInstallerAsync(OperatingSystem operatingSystem)
    {
        var fileForOSType = operatingSystem == OperatingSystem.Windows ? WindowsConsoleSetupFileName : MacOSConsoleSetupFileName;
        
        var filePath = $"{_configuration[ConsoleSetupFilePathSection]}/{fileForOSType}";

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        return File(
            await System.IO.File.ReadAllBytesAsync(filePath),
            OctetStreamMimeTypeName,
            fileForOSType);
    }
}
