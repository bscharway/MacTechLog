
using MaintenanceLogsService.Data;
using MaintenanceLogsService.MappingProfiles;
using MaintenanceLogsService.Repository;
using MaintenanceLogsService.Sevices;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceLogsService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<MaintenanceLogsContext>(options => options.UseSqlServer(
            builder.Configuration["ConnectionStrings:LocalDev"]));

        builder.Services.AddScoped<IMaintenanceLogRepository, MaintenanceLogRepository>();
        builder.Services.AddScoped<IMaintenanceLogService, MaintenanceLogService>();

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaintenanceLogsService v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
