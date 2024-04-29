using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class UsernameAlreadyRegisteredException : RequestException
{
    public UsernameAlreadyRegisteredException() : base(
        "Username is already registered. Try another one",
        ErrorType.InvalidUsername,
        HttpStatusCode.BadRequest)
    {
    }
}