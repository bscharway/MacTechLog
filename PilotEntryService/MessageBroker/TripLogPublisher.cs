using System.Text;
using System.Text.Json;
using PilotEntryService.Models.Entities;
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
            factory.ClientProvidedName = "Trip Log Publisher";
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            string exchangeName = "trip_log_exchange";
            string queueName = "trip_log_queue";
            string routingKey = "";

            // Declare exchange and queue for message routing
            _channel.ExchangeDeclare(exchangeName, type: ExchangeType.Fanout);
            _channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, routingKey, arguments:null);
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

        // PilotEntryService - Updated to publish event with FuelConsumed
        public async Task LogTripCompletion(TripLog tripLog)
        {
            var completedEvent = new TripLogCompletedEvent
            {
                AircraftRegistration = tripLog.AircraftRegistration,
                FlightHours = double.Parse(tripLog.ArrivalTime - tripLog.DepartureTime),
                Cycles = tripLog.Cycles,
                FuelConsumed = tripLog.FuelConsumed // Include fuel consumed
            };

            _tripLogPublisher.PublishTripLogCompletedEvent(completedEvent);
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

    // TripLogCompletedEvent - Updated to include FuelConsumed
    public class TripLogCompletedEvent
    {
        public string AircraftRegistration { get; set; }
        public double FlightHours { get; set; }
        public int Cycles { get; set; }
        public int FuelConsumed { get; set; } // Amount of fuel consumed during the trip
    }
}
