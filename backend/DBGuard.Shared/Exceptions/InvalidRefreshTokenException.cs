using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class InvalidRefreshTokenException : RequestException
{
    public InvalidRefreshTokenException() : base(
        "Invalid refresh token!",
        ErrorType.InvalidToken,
        HttpStatusCode.BadRequest)
    {
    }
}