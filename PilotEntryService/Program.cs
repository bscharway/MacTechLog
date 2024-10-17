
using PilotEntryService.Data;
using PilotEntryService.Repositories.Interfaces;
using PilotEntryService.Repositories;
using PilotEntryService.Services.Interfaces;
using PilotEntryService.Services;
using Microsoft.EntityFrameworkCore;
using PilotEntryService.MappingProfiles;
using PilotEntryService.MessageBroker;
using Microsoft.OpenApi.Models;
//using PilotEntryService.Data.SeedData;


namespace PilotEntryService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<PilotEntryContext>(options => options.UseSqlServer(
            builder.Configuration["ConnectionStrings:LocalDev"]));

        builder.Services.AddScoped<ITripLogRepository, TripLogRepository>();
        builder.Services.AddScoped<ITripLogService, Services.TripLogService>();
        builder.Services.AddSingleton<TripLogPublisher>();


        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pilot Entry API", Version = "v1" });
        });

        var app = builder.Build();

        // Seed the database
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<PilotEntryContext>();
            //SeedData.Initialize(context);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PilotEntryService v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

