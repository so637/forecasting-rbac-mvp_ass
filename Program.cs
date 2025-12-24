using Forecast.Api.Data;
using Forecast.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ ADD CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=forecast.db"));

var app = builder.Build();

// SEED USERS
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new User { Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Username = "manager", Password = "manager123", Role = "Manager" },
            new User { Username = "user", Password = "user123", Role = "User" }
        );
        db.SaveChanges();
    }
}

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// USE CORS HERE
app.UseCors("AllowReact");

app.UseStaticFiles();
app.MapControllers();
app.Run();
