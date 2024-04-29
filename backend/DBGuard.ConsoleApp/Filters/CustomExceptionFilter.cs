using DBGuard.ConsoleApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DBGuard.ConsoleApp.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var (statusCode, _) = exception.ParseException();
        var response = new ObjectResult(exception.Message)
        {
            StatusCode = (int)statusCode
        };
        
        context.Result = response;

        context.ExceptionHandled = true;
    }
}