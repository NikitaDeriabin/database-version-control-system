using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DBGuard.SqlService.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
