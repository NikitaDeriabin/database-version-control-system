using System.Net;
using DBGuard.Shared.Enums;

namespace DBGuard.Shared.Exceptions.Abstract;

public abstract class RequestException : Exception
{
    public ErrorType ErrorType { get; }
    public HttpStatusCode StatusCode { get; }

    public RequestException(string message, ErrorType errorType, HttpStatusCode statusCode) : base(message)
    {
        ErrorType = errorType;
        StatusCode = statusCode;
    }
}