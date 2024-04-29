using DBGuard.Core.DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DBGuard.Core.DAL.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseDbGuardCoreContext(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        using var context = scope?.ServiceProvider.GetRequiredService<DbGuardCoreContext>();
        context?.Database.Migrate();
    }
}