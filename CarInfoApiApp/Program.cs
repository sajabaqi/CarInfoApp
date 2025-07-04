using CarInfoApiApp.Services;
using Microsoft.AspNetCore.Builder; 
using Microsoft.Extensions.DependencyInjection; // For AddControllers, AddHttpClient, AddScoped
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient<IMakeService, MakeService>();

builder.Services.AddScoped<IMakeService, MakeService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", // Define a CORS policy named "AllowAll"
        builder =>
        {
            builder
                .AllowAnyOrigin() // Allow requests from any origin (domain)
                .AllowAnyMethod() // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.)
                .AllowAnyHeader(); // Allow all HTTP headers
        });
});

// Add Swagger/OpenAPI support for API documentation and testing
builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Car Information API",
        Version = "v1",
        Description = "API for retrieving car makes and vehicle types from NHTSA database"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Information API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root (e.g., http://localhost:5000/ )
    });
}
app.UseCors("AllowAll");

app.MapControllers();

// Configure the app to listen on all network interfaces (0.0.0.0) and port 5000.
// This is important for Docker and for accessing the API from other machines/containers.
app.Urls.Add("http://0.0.0.0:5000");

app.Run();
