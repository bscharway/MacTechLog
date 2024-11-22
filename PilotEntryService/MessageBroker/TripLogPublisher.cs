using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace PilotEntryService.MessageBroker
{
    /// <summary>
    /// RabbitMQ Publisher for TripLog messages.
    /// </summary>
    public class TripLogPublisher : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripLogPublisher"/> class.
        /// Sets up the RabbitMQ connection, channel, exchange, and queues.
        /// </summary>



        public TripLogPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            factory.ClientProvidedName = "Trip Log Publisher";
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            string exchangeName = "trip_log_exchange";
            string flightHoursQueue = "flight_hours_update_queue";
            string fuelManagementQueue = "fuel_management_update_queue";
            string maintenanceQueue = "trip_log_queue";

            // Declare exchange and queues for message routing
            _channel.ExchangeDeclare(exchangeName, type: ExchangeType.Fanout);
            _channel.QueueDeclare(flightHoursQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(fuelManagementQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueDeclare(maintenanceQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Bind queues to exchange
            _channel.QueueBind(flightHoursQueue, exchangeName, routingKey: "");
            _channel.QueueBind(fuelManagementQueue, exchangeName, routingKey: "");
            _channel.QueueBind(maintenanceQueue, exchangeName, routingKey: "");
        }

        /// <summary>
        /// Publishes a TripLogCompletedEvent message to the RabbitMQ exchange.
        /// </summary>
        /// <param name="completedEvent">The TripLogCompletedEvent to publish.</param>
        public void PublishTripLogCompletedEvent(TripLogCompletedEvent completedEvent)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(completedEvent));

            _channel.BasicPublish(exchange: "trip_log_exchange",
                                  routingKey: "",
                                  basicProperties: null,
                                  body: body);
        }

        /// <summary>
        /// Disposes the RabbitMQ connection and channel.
        /// </summary>
        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }

    /// <summary>
    /// Represents a TripLog message to be published to RabbitMQ.
    /// </summary>
    public class TripLogCompletedEvent
    {
        /// <summary>
        /// Gets or sets the unique identifier for the TripLog.
        /// </summary>
        public int TripLogId { get; set; }

        /// <summary>
        /// Gets or sets the aircraft registration number.
        /// </summary>
        public string AircraftRegistration { get; set; }

        /// <summary>
        /// Gets or sets the number of flight hours to add.
        /// </summary>
        public int FlightHours { get; set; }

        /// <summary>
        /// Gets or sets the number of cycles to add.
        /// </summary>
        public int Cycles { get; set; }

        /// <summary>
        /// Gets or sets the amount of fuel consumed during the trip.
        /// </summary>
        public double? LandingFuel { get; set; }

        /// <summary>
        /// Gets or sets the remark related to the TripLog.
        /// </summary>
        public string Remark { get; set; }
    }
}
