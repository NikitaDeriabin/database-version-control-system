using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class InvalidEmailOrPasswordException : RequestException
{
    public InvalidEmailOrPasswordException() : base(
        "Invalid email or password.",
        ErrorType.InvalidEmailOrPassword,
        HttpStatusCode.BadRequest)
    {
    }
}