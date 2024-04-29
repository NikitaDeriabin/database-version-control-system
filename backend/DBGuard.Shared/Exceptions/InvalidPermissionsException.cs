using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class InvalidPermissionsException : RequestException
{
    public InvalidPermissionsException() : base(
        "Don't have permission to perform this action",
        ErrorType.InvalidPermission,
        HttpStatusCode.Forbidden)
    {
    }
}