﻿using DBGuard.Core.DAL.Entities;
using DBGuard.SqlService.BLL.Interfaces;
using DBGuard.SqlService.BLL.Interfaces.ConsoleAppHub;
using DBGuard.SqlService.BLL.Models.Options;
using DBGuard.SqlService.BLL.Services;
using DBGuard.SqlService.BLL.Services.ConsoleAppHub;
using DBGuard.SqlService.BLL.Services.SqlFormatter;
using Microsoft.Extensions.Options;

namespace DBGuard.SqlService.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IResultObserver, ResultObserver>();
        services.AddSingleton<IProcessReceivedDataService, ProcessReceivedDataService>();

        services.AddScoped<ITextService, TextService>();
        services.AddScoped<IDependencyAnalyzer, DependencyAnalyzer>();
        services.AddScoped<IDbItemsRetrievalService, DbItemsRetrievalService>();
        services.AddScoped<IChangesLoaderService, ChangesLoaderService>();
        services.AddScoped<IContentDifferenceService, ContentDifferenceService>();
        services.AddScoped<IApplyChangesService, ApplyChangesService>();
        services.AddScoped<ICreateTableScriptService, CreateTableScriptService>();
        services.AddSingleton<IProcessReceivedDataService, ProcessReceivedDataService>();
        services.AddScoped<ICommitFilesService, CommitFilesService>();

        services.AddScoped<ISqlFormatterService, SqlFormatterService>(_ =>
            new SqlFormatterService(configuration.GetSection("PythonExePath")!.Value));
    }

    public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigin = configuration.GetRequiredSection("CoreWebAPIDomain")!.Value;
        services.AddCors(options =>
            options.AddDefaultPolicy(policy =>
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(allowedOrigin)));
    }

    public static void AddMongoDbService(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDatabaseSection = "MongoDatabase";
        var collectionName = "UserCollection";

        services.Configure<MongoDatabaseConnectionSettings>(configuration.GetSection(mongoDatabaseSection)!);

        services.AddTransient<IMongoService<User>>(s =>
            new MongoService<User>(s.GetRequiredService<IOptions<MongoDatabaseConnectionSettings>>(),
                collectionName));
    }
}