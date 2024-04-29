using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class HttpRequestException : RequestException
{
    public HttpRequestException(string message) : base(
        message,
        ErrorType.HttpRequest,
        HttpStatusCode.BadRequest)
    {
    }
}