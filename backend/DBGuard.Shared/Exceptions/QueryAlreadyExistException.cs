using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class QueryAlreadyExistException : RequestException
{
    public QueryAlreadyExistException(Guid queryId) : base(
        $"Query with ID: {queryId} was not registered or has expired",
        ErrorType.QueryExpired,
        HttpStatusCode.BadRequest)
    {
    }
}