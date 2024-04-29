using DBGuard.Core.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DBGuard.Core.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDbGuardCoreContext(this IServiceCollection services, IConfiguration configuration)
    {
        var squirrelCoreDbConnectionString = "SquirrelCoreDBConnection";
        var connectionsString = configuration.GetConnectionString(squirrelCoreDbConnectionString);
        services.AddDbContext<DbGuardCoreContext>(options =>
            options.UseSqlServer(
                connectionsString,
                opt => opt.MigrationsAssembly(typeof(DbGuardCoreContext).Assembly.GetName().Name)));
    }
}
