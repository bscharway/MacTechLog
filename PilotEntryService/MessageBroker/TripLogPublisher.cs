using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace PilotEntryService.MessageBroker
{
    public class TripLogPublisher : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

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

        public void PublishTripLog(TripLogMessage message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            _channel.BasicPublish(exchange: "trip_log_exchange",
                                  routingKey: "",
                                  basicProperties: null,
                                  body: body);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }

    public class TripLogMessage
    {
        public int TripLogId { get; set; }
        public string AircraftRegistration { get; set; }
        public string Remark { get; set; }
    }
}
