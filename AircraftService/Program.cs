
using AircraftService.Data;
using AircraftService.Repositories;
using AircraftService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AircraftService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        // Configuration for DbContext using ConnectionString from appsettings.json
        builder.Services.AddDbContext<AircraftDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDev")));

        // Add repository and service dependencies
        builder.Services.AddScoped<IAircraftRepository, AircraftRepository>();
        builder.Services.AddScoped<IAircraftService, AircraftService.Services.AircraftService>();
        builder.Services.AddScoped<IFuelManagementRepository, FuelManagementRepository>();
        builder.Services.AddScoped<ITripLogService, TripLogService>();
        builder.Services.AddScoped<IFuelManagementService,  FuelManagementService>();

        builder.Services.AddHostedService<FlightHoursUpdateListener>();


        // AutoMapper configuration
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
