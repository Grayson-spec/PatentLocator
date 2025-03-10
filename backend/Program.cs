using backend.Data;
using backend.Infrastructure;
using backend.Interfaces;
using backend.Logging;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);


//
// CORS middleware is implemented here.
//
//
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.RegisterServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

app.UseCors();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
    await next();
});

app.MapControllers();
app.Run();


