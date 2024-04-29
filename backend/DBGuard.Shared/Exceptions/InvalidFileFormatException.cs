using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class InvalidFileFormatException : RequestException
{
    public InvalidFileFormatException(string types) : base(
        $"Invalid file type, need {types}",
        ErrorType.InvalidFileFormat,
        HttpStatusCode.UnsupportedMediaType)
    {
    }
}