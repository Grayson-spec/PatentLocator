using backend.Data;
using backend.Infrastructure;
using backend.Interfaces;
using backend.Logging;
using backend.Services.Interfaces;
using backend.Services;
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

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.RegisterServices();

builder.Services.AddScoped<ISavedPatentService, SavedPatentService>();

builder.Services.AddControllers();

// ✅ REVERTED: Simple, original DB setup
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
    await next();
});

app.MapControllers();
app.Run();
