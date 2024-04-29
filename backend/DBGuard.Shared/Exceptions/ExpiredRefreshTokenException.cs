using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class ExpiredRefreshTokenException : RequestException
{
    public ExpiredRefreshTokenException() : base(
        "Refresh token expired.",
        ErrorType.RefreshTokenExpired,
        HttpStatusCode.Forbidden)
    {
    }
}