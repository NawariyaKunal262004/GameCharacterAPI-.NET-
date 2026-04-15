// Program.cs - entry point for the Web API application
// This file configures services (like controllers, database and OpenAPI)
// and defines how the HTTP request pipeline will behave when the app runs.

using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register MVC controllers so the app can respond to HTTP requests.
builder.Services.AddControllers();

// Register OpenAPI/Swagger helpers so API documentation is available in development.
builder.Services.AddOpenApi();

// Register the application's EF Core DbContext and point it to the configured SQL Server.
// The connection string is read from appsettings.json (DefaultConnection).
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the service that contains business logic for characters.
// We use scoped lifetime so a new instance is created per HTTP request.
builder.Services.AddScoped<IVideoGameCharacterService, VideoGameCharacterService>();

var app = builder.Build();

// Configure middleware pipeline. In development we enable API documentation UI.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Redirect HTTP to HTTPS for secure communication.
app.UseHttpsRedirection();

// Enable authorization middleware (no authentication configured here, but this is standard).
app.UseAuthorization();

// Map controller routes so endpoints are reachable.
app.MapControllers();

// Start the web application and begin listening for HTTP requests.
app.Run();

// Expose Program class for integration tests (WebApplicationFactory requires a type).
public partial class Program { }
