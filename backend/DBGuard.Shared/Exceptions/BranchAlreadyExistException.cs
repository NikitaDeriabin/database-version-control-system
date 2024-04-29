using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class BranchAlreadyExistException : RequestException
{
    public BranchAlreadyExistException() : base(
        "Branch with this name already exists in project",
        ErrorType.InvalidBranchName,
        HttpStatusCode.BadRequest)
    {
    }
}
