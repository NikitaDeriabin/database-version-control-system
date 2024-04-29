using DBGuard.Core.DAL.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DBGuard.Core.DAL.Context;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
    }
}