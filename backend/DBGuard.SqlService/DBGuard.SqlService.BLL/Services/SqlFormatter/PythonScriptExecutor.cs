using System.Diagnostics;
using DBGuard.Shared.Exceptions;

namespace DBGuard.SqlService.BLL.Services.SqlFormatter;

public static class PythonScriptExecutor
{
    public static void ExecuteScript(ProcessStartInfo startInfo, out string result)
    {
        using var process = Process.Start(startInfo)!;
        using var reader = process.StandardOutput;
        var errors = process.StandardError.ReadToEnd();
        if (errors.Any())
        {
            throw new Exception(errors);
        }
            
        var hasErrors = reader.ReadLine();
        if (hasErrors == "True")
        {
            throw new SqlSyntaxException(reader.ReadToEnd());
        }
            
        result = reader.ReadToEnd();
        process.WaitForExit();
    }
}