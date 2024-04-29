using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class EntityNotFoundException : RequestException
{
    public EntityNotFoundException() : base(
        "Entity not found.",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }

    public EntityNotFoundException(string entityName) : base(
        $"Entity '{entityName}' not found",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }

    public EntityNotFoundException(string entityName, int id) : base(
        $"Entity '{entityName}' with id '{id}' not found",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }

    public EntityNotFoundException(string entityName, string property) : base(
        $"Entity '{entityName}' not found by '{property}' ",
        ErrorType.NotFound,
        HttpStatusCode.NotFound)
    {
    }
}