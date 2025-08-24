using BusinessLogic.Services;
using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// DB context
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite("Data Source=flights.db"));

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddScoped<FlightService>();
builder.Services.AddScoped<PassengerService>();
builder.Services.AddScoped<ReservationService>();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

var app = builder.Build();

// REST + SignalR
app.MapControllers();
app.MapHub<FlightStatusHub>("/flightHub");

// SocketServer-ийг background-д ажиллуулах
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    db.Database.EnsureCreated();
    DbInitializer.Seed(db);
    var socketServer = new SocketServer(db);
    _ = socketServer.StartAsync(6000); // background thread
}

app.Run();
