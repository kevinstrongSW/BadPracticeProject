using BadPracticeProject.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Wide-open CORS (vulnerability)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Hardcoded secret key
var jwtSecret = "THIS_IS_NOT_SECURE_123456789";

// Missing security headers
app.Use(async (ctx, next) =>
{
    await next();
});

Database.ConnectionString = "Server=localhost;Database=BadBank;User Id=sa;Password=SuperSecret123;";

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
