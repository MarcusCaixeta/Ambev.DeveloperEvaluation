using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Common.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace Ambev.DeveloperEvaluation.Infrastructure.Messaging
{
    /// <summary>
    /// Implementation of IMessagingService using RabbitMQ
    /// </summary>
    public class RabbitMQService : IMessagingService, IDisposable
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IChannel _channel;

        /// <summary>
        /// Initializes a new instance of RabbitMQService
        /// </summary>
        public RabbitMQService()
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@rabbitmq:5672/")
            };
            _connection = _factory.CreateConnectionAsync().GetAwaiter().GetResult();
            _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();

            // Ensures required queues exist
            CreateQueue("sale_cancelled_queue");
            CreateQueue("sale_item_cancelled_queue");
            CreateQueue("sale_modified_queue");
            CreateQueue("sale_created_queue");
        }

        /// <summary>
        /// Publishes a message to the specified queue
        /// </summary>
        /// <param name="queueName">The name of the target queue</param>
        /// <param name="message">The message object to be published</param>
        public async Task Publish(string queueName, object message)
        {
            try
            {
                await _channel.QueueDeclareAsync(queue: queueName,
                                                 durable: true,
                                                 exclusive: false,
                                                 autoDelete: false,
                                                 arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                var properties = new BasicProperties
                {
                    Persistent = true
                };

                await _channel.BasicPublishAsync(exchange: "",
                                                 routingKey: queueName,
                                                 mandatory: true,
                                                 basicProperties: properties,
                                                 body: body);
            }
            catch (BrokerUnreachableException ex)
            {
                throw new Exception("RabbitMQ broker is unreachable.", ex);
            }
        }

        /// <summary>
        /// Declares a queue in RabbitMQ to ensure it exists
        /// </summary>
        /// <param name="queueName">The name of the queue to create</param>
        private void CreateQueue(string queueName)
        {
            try
            {
                _channel.QueueDeclareAsync(queue: queueName,
                                           durable: true,
                                           exclusive: false,
                                           autoDelete: false,
                                           arguments: null);
                Console.WriteLine($"Queue created/verified: {queueName}");
            }
            catch (BrokerUnreachableException ex)
            {
                Console.WriteLine($"Error connecting to RabbitMQ: {ex.Message}");
            }
        }

        /// <summary>
        /// Disposes of the RabbitMQ connection and channel
        /// </summary>
        public void Dispose()
        {
            _channel?.CloseAsync().GetAwaiter().GetResult();
            _connection?.CloseAsync().GetAwaiter().GetResult();
        }
    }
}
