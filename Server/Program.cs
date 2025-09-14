using BusinessLogic.Services;
using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Server.Hubs;
using Server.Notifier.Interfaces;
using Server.Notifier;

var builder = WebApplication.CreateBuilder(args);

// DB context
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite("Data Source=flights.db"));

// SignalR
builder.Services.AddSignalR();

// Controllers
builder.Services.AddControllers();

// Services
builder.Services.AddScoped<FlightService>();
builder.Services.AddScoped<PassengerService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddSingleton<IFlightNotifier, SignalRFlightNotifier>();
builder.Services.AddSingleton<ISeatNotifier, SignalRSeatNotifier>(); 



// Repositories
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("client", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5023", // Blazor HTTP
                "https://localhost:7197" // Blazor HTTPS
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("client");
//app.UseHttpsRedirection();

// REST + SignalR
app.MapControllers();
app.MapHub<FlightStatusHub>("/flightHub");
app.MapHub<SeatHub>("/seatHub");

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