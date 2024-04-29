using System.Net;
using DBGuard.ConsoleApp.BL.Exceptions;
using DBGuard.ConsoleApp.Models;

namespace DBGuard.ConsoleApp.Extensions;

public static class ExceptionFilterExtensions
{
    public static (HttpStatusCode statusCode, ErrorCode errorCode) ParseException(this Exception exception)
    {
        return exception switch
        {
            ConnectionFileNotFound _ => (HttpStatusCode.NotFound, ErrorCode.FileNotFound),
            JsonReadFailed _ => (HttpStatusCode.NotFound, ErrorCode.FileDamage),
            _ => (HttpStatusCode.InternalServerError, ErrorCode.General),
        };
    }
}