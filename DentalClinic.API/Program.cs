using DentalClinic.Application;
using DentalClinic.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
