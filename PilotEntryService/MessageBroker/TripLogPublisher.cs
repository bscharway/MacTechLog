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
        /// Sets up the RabbitMQ connection, channel, exchange, and queue.
        /// </summary>
        public TripLogPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare exchange and queue for message routing
            _channel.ExchangeDeclare(exchange: "trip_log_exchange", type: ExchangeType.Fanout);
            _channel.QueueDeclare(queue: "trip_log_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: "trip_log_queue", exchange: "trip_log_exchange", routingKey: "");
        }

        /// <summary>
        /// Publishes a TripLog message to the RabbitMQ exchange.
        /// </summary>
        /// <param name="message">The TripLog message to publish.</param>
        public void PublishTripLog(TripLogMessage message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

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
    public class TripLogMessage
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
        /// Gets or sets the remark related to the TripLog.
        /// </summary>
        public string Remark { get; set; }
    }
}
