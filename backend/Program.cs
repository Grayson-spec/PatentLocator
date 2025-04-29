using backend.Data;
using backend.Interfaces;
using backend.Logging;
using backend.Repositories;
using backend.Repositories.Interfaces;
using backend.Services;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ CORS for frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ✅ MANUAL SERVICE REGISTRATION
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISavedPatentService, SavedPatentService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISavedPatentRepository, SavedPatentRepository>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();

builder.Services.AddControllers();

// ✅ HARD-CODED PATH TO CORRECT DATABASE
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(@"Data Source=C:\Users\Jack\Downloads\patentsdatabase.db"));

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
    await next();
});

app.MapControllers();

// ✅ Final log so you can confirm it
Console.WriteLine("🔒 USING DATABASE → C:\\Users\\Jack\\Downloads\\patentsdatabase.db");

app.Run();
