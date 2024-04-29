using DBGuard.AzureBlobStorage.Extensions;
using DBGuard.Core.DAL.Extensions;
using DBGuard.Shared.Extensions;
using DBGuard.Shared.Middlewares;
using DBGuard.SqlService.BLL.Extensions;
using DBGuard.SqlService.BLL.Hubs;
using DBGuard.SqlService.WebApi.Extensions;
using DBGuard.SqlService.WebApi.Middlewares;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbGuardCoreContext(builder.Configuration);
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.AddMongoDbService(builder.Configuration);
builder.Services.AddAzureBlobStorage(builder.Configuration);
builder.Services.AddSignalR(o =>
{
    o.EnableDetailedErrors = true;
    o.MaximumReceiveMessageSize = 1024 * 300;
});
builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
builder.Services.RegisterCustomServices(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://*:5076");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GenericExceptionHandlerMiddleware>();
app.UseMiddleware<SignalRMiddleware>();

app.UseHttpsRedirection();

app.UseDbGuardCoreContext();

app.UseConsoleAppHub();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
