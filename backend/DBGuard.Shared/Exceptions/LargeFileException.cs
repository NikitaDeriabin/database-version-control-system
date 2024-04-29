using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class LargeFileException : RequestException
{
    public LargeFileException(string maxSize) : base(
        $"The file size should not exceed {maxSize}",
        ErrorType.LargeFile,
        HttpStatusCode.RequestEntityTooLarge)
    {
    }
}