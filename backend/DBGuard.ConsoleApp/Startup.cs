﻿using DBGuard.ConsoleApp.BL.Interfaces;
using DBGuard.ConsoleApp.BL.Services;
using DBGuard.ConsoleApp.BL.Validators;
using DBGuard.ConsoleApp.Extensions;
using DBGuard.ConsoleApp.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace DBGuard.ConsoleApp;

public class Startup
{
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                                                          .SetBasePath(AppContext.BaseDirectory)
                                                          .AddJsonFile(Program.AppSettingsFileName, optional: false, reloadOnChange: true)
                                                          .Build();

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IConnectionFileService, ConnectionFileService>();
        services.AddScoped<IClientIdFileService, ClientIdFileService>();
        services.AddScoped<IConnectionStringService, ConnectionStringService>();
        services.AddTransient<IGetActionsService, GetActionsService>();
        services.AddScoped<IJsonSerializerSettingsService, JsonSerializerSettingsService>();
        services.AddScoped<IConnectionService, ConnectionService>();

        var serviceProvider = services.BuildServiceProvider();
        var connectionStringService = serviceProvider.GetRequiredService<IConnectionStringService>();
        var connectionFileService = serviceProvider.GetRequiredService<IConnectionFileService>();
       
        connectionFileService.CreateInitFile();
        var connectionString = connectionFileService.ReadFromFile();

        Console.WriteLine($"DB Settings:\n - DbType: {connectionString.DbEngine}\n - Connection string: {connectionStringService.BuildConnectionString(connectionString)}");
       
        services.AddScoped<IDbQueryProvider>(_ => DatabaseServiceFactory.CreateDbQueryProvider(connectionString.DbEngine));
        services.AddScoped<IDatabaseService>(_ => DatabaseServiceFactory.CreateDatabaseService(connectionString.DbEngine, connectionStringService.BuildConnectionString(connectionString)));

        services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ConnectionStringDtoValidator>());
        
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(CustomExceptionFilter));
        });

        services.AddControllers().AddNewtonsoftJson(jsonOptions =>
        {
            jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.RegisterHubs(Configuration);

        app.UseCors(builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseEndpoints(cfg =>
        {
            cfg.MapControllers();
        });
    }
}