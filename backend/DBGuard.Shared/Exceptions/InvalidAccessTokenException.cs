using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class InvalidAccessTokenException : RequestException
{
    public InvalidAccessTokenException() : base(
        "Invalid access token!",
        ErrorType.InvalidToken,
        HttpStatusCode.BadRequest)
    {
    }
}