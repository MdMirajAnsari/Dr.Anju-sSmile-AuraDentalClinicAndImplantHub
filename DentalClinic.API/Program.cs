using DentalClinic.API.Jobs;
using DentalClinic.API.Middleware;
using DentalClinic.Application;
using DentalClinic.Infrastructure;
using DentalClinic.Persistence;
using DentalClinic.Security;
using DentalClinic.Security.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddSecurityServices();

builder.Services.AddHostedService<AppointmentsReminderJob>();

var app = builder.Build();


app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Enable middleware to serve generated Swagger as a JSON endpoint and the Swagger UI.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentalClinic API v1");
        c.RoutePrefix = string.Empty; // serve UI at app root
    });
}
app.UseCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
