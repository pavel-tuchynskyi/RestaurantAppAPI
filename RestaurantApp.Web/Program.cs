using RestaurantApp.Application.Configuration;
using RestaurantApp.Infrastructure.Configuration;
using RestaurantApp.Infrastructure.Data.Seeder;
using RestaurantApp.Web.Configuration;
using RestaurantApp.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
