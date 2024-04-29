using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public class QueryExpiredException : RequestException
{
    public QueryExpiredException(Guid queryId) : base(
        $"Query with ID: {queryId} is already exist in project",
        ErrorType.InvalidQuery,
        HttpStatusCode.BadRequest)
    {
    }
}