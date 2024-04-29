using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class InvalidPasswordException : RequestException
{
    public InvalidPasswordException() : base(
        "Invalid password.",
        ErrorType.InvalidPassword,
        HttpStatusCode.BadRequest)
    {
    }
}