using RestaurantApp.Application.Configuration;
using RestaurantApp.Infrastructure.Configuration;
using RestaurantApp.Infrastructure.Data.Seeder;
using RestaurantApp.Web.Configuration;
using RestaurantApp.Web.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.MinimumLevel.Information()
        .WriteTo.Console();
});

var configuration = builder.Configuration;

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(configuration)
    .AddWebServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.SeedDbData();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AppCors");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
