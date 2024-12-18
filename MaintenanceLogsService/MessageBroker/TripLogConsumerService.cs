﻿using AutoMapper;
using MaintenanceLogsService.Services;
//using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
//using EFCoreModel = Microsoft.EntityFrameworkCore.Metadata.IModel;
using MaintenanceLogsService.Models.DTOs;

namespace MaintenanceLogsService.MessageBroker
{
    public class TripLogConsumerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private IConnection _connection;
        private IModel _channel;

        public TripLogConsumerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            factory.ClientProvidedName = "Trip Log Receiver";
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            string exchangeName = "trip_log_exchange";
            string queueName = "trip_log_queue";
            string routingKey = "";

            _channel.ExchangeDeclare(exchangeName, type: ExchangeType.Fanout);
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queueName, exchangeName, routingKey, arguments: null);
            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, args) =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var maintenanceLogService = scope.ServiceProvider.GetRequiredService<IMaintenanceLogService>();
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var tripLogMessage = JsonSerializer.Deserialize<TripLogMessage>(message);

                    if (tripLogMessage != null && !string.IsNullOrEmpty(tripLogMessage.Remark))
                    {
                        var createTicketDto = new CreateMaintenanceTicketDto
                        {
                            AircraftRegistration = tripLogMessage.AircraftRegistration,
                            Description = $"Ticket triggered by Trip Log: {tripLogMessage.Remark}",
                            TripLogId = tripLogMessage.TripLogId
                        };

                        await maintenanceLogService.AddMaintenanceTicketAsync(createTicketDto);
                    }
                }
            };

            _channel.BasicConsume(queue: "trip_log_queue", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
