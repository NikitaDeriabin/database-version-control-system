using System.Net;
using DBGuard.Shared.Enums;
using DBGuard.Shared.Exceptions.Abstract;

namespace DBGuard.Shared.Exceptions;

public sealed class SqlSyntaxException : RequestException
{
    public SqlSyntaxException(string parserErrorMessage) : base(
        parserErrorMessage,
        ErrorType.SqlSyntax,
        HttpStatusCode.BadRequest)
    {
    }
}