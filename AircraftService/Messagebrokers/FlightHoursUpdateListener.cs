// FlightHoursUpdateListener in AircraftService - Updated to handle fuel management
using AircraftService.Services;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

public class FlightHoursUpdateListener : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly ILogger<FlightHoursUpdateListener> _logger;

    public FlightHoursUpdateListener(IServiceProvider serviceProvider, ILogger<FlightHoursUpdateListener> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;

        try
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                ClientProvidedName = "FlightHoursUpdateListener"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            string exchangeName = "trip_log_exchange";
            string flightHoursQueue = "flight_hours_update_queue";
            string fuelManagementQueue = "fuel_management_update_queue";
            string routingKey = "";

            // Declare exchange and queues for message routing
            _channel.ExchangeDeclare(exchangeName, type: ExchangeType.Fanout);
            _channel.QueueDeclare(queue: flightHoursQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(queue: fuelManagementQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(flightHoursQueue, exchangeName, routingKey, arguments: null);
            _channel.QueueBind(fuelManagementQueue, exchangeName, routingKey, arguments: null);
            _channel.BasicQos(0, 1, false);

            _logger.LogInformation("FlightHoursUpdateListener successfully connected to RabbitMQ.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error initializing FlightHoursUpdateListener: {ex.Message}");
        }
    }


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_channel == null)
        {
            _logger.LogError("RabbitMQ channel is not initialized.");
            return Task.CompletedTask;
        }

        startLoggedTripConsumer();
        StartFlightHoursUpdateConsumer();
        StartFuelManagementUpdateConsumer();

        _logger.LogInformation("AircraftUpdateListener started listening to queues.");
        return Task.CompletedTask;

        //return Task.CompletedTask;
    }

    private void startLoggedTripConsumer()
    {
        var flightHoursConsumer = new EventingBasicConsumer(_channel);
        flightHoursConsumer.Received += async (model, ea) =>
        {
            using var scope = _serviceProvider.CreateScope();
            var aircraftService = scope.ServiceProvider.GetRequiredService<IAircraftService>();

            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var tripLogCompletedEvent = JsonSerializer.Deserialize<TripLogCompletedEvent>(message);

            if (tripLogCompletedEvent != null)
            {
                _logger.LogInformation($"Received flight hours update message: TripLogId={tripLogCompletedEvent.TripLogId}, AircraftId={tripLogCompletedEvent.AircraftRegistration}");

                try
                {
                    await aircraftService.UpdateFlightHoursCyclesAndFuelAsyncFromMessageBroker(
                        tripLogCompletedEvent.AircraftRegistration,
                        tripLogCompletedEvent.FlightHours,
                        tripLogCompletedEvent.Cycles,
                        tripLogCompletedEvent.LandingFuel,
                        tripLogCompletedEvent.TripLogId,
                        tripLogCompletedEvent.MaintenanceLogId
                    );
                    _channel.BasicAck(ea.DeliveryTag, multiple: false);
                    _logger.LogInformation($"Processed flight hours update message for TripLogId={tripLogCompletedEvent.TripLogId}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error processing message for TripLogId={tripLogCompletedEvent.TripLogId}: {ex.Message}");
                    _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: true);
                }
            }
            else
            {
                _logger.LogWarning("Received an empty or invalid flight hours update message.");
                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            }
        };

        _channel.BasicConsume(queue: "flight_hours_update_queue", autoAck: true, consumer: flightHoursConsumer);

        _logger.LogInformation("FlightHoursUpdateListener started listening to queues.");
    }

    private void StartFlightHoursUpdateConsumer()
    {

        // code for updating flight hours and cycles only 

    }

    private void StartFuelManagementUpdateConsumer()
    {

        // code for updating fuel management only

    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
        base.Dispose();
    }
}





// TripLogCompletedEvent - Updated to include FuelConsumed
public class TripLogCompletedEvent
{
    public string AircraftRegistration { get; set; }
    public int FlightHours { get; set; }
    public int Cycles { get; set; }
    public int LandingFuel { get; set; }
    public int TripLogId { get; set; }
    public int MaintenanceLogId { get; set; }
}