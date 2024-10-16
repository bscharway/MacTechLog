
using MaintenanceLogsService.Data;
using MaintenanceLogsService.MappingProfiles;
using MaintenanceLogsService.MessageBroker;
using MaintenanceLogsService.Repository;
using MaintenanceLogsService.Sevices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MaintenanceLogsService;

// Program.cs - Dependency Injection Setup
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<MaintenanceLogsContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionStrings:LocalDev"]));

        builder.Services.AddScoped<IMaintenanceLogRepository, MaintenanceLogRepository>();
        builder.Services.AddScoped<IMaintenanceTicketRepository, MaintenanceTicketRepository>();
        builder.Services.AddScoped<IMaintenanceLogService, MaintenanceLogService>();

        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers();

        // Add Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Maintenance Logs API", Version = "v1" });
        });

        // Register the RabbitMQ consumer as a hosted service
        builder.Services.AddHostedService<TripLogConsumerService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Maintenance Logs API v1"));
        }

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}


