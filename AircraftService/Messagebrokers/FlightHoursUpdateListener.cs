// FlightHoursUpdateListener in AircraftService - Updated to handle fuel management
using AircraftService.Services;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class FlightHoursUpdateListener : BackgroundService
{
    private readonly IAircraftService _aircraftService;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public FlightHoursUpdateListener(IAircraftService aircraftService)
    {
        _aircraftService = aircraftService;
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "flight_hours_update_queue", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueDeclare(queue: "fuel_management_update_queue", durable: true, exclusive: false, autoDelete: false);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var tripLogCompletedEvent = JsonSerializer.Deserialize<TripLogCompletedEvent>(message);

            if (tripLogCompletedEvent != null)
            {
                await _aircraftService.UpdateFlightHoursCyclesAndFuelAsync(
                    tripLogCompletedEvent.AircraftId,
                    tripLogCompletedEvent.FlightHours,
                    tripLogCompletedEvent.Cycles,
                    tripLogCompletedEvent.FuelConsumed);
            }
        };
        _channel.BasicConsume(queue: "flight_hours_update_queue", autoAck: true, consumer: consumer);
        _channel.BasicConsume(queue: "fuel_management_update_queue", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}


// TripLogCompletedEvent - Updated to include FuelConsumed
public class TripLogCompletedEvent
{
    public int AircraftId { get; set; }
    public int FlightHours { get; set; }
    public int Cycles { get; set; }
    public int FuelConsumed { get; set; } // Amount of fuel consumed during the trip
}