﻿using AutoMapper;
using MaintenanceLogsService.Sevices;
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
        private readonly IMaintenanceLogService _maintenanceLogService;
        private readonly IMapper _mapper;
        private IConnection _connection;
        RabbitMQ.Client.IModel _channel;

        public TripLogConsumerService(IMaintenanceLogService maintenanceLogService, IMapper mapper)
        {
            _maintenanceLogService = maintenanceLogService;
            _mapper = mapper;

            // Set up RabbitMQ connection and channel
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "trip_log_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
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

                    await _maintenanceLogService.AddMaintenanceTicketAsync(createTicketDto);
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