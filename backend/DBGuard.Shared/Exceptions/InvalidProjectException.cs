using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class InvalidProjectException : RequestException
{
    public InvalidProjectException() : base(
        "Such project does not exist!",
        ErrorType.InvalidProject,
        HttpStatusCode.BadRequest)
    {
    }
}