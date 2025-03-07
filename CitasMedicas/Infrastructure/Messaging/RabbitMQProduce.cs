using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text.Json;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CitasMedicas.Domain.Interfaces;
using System.Threading.Tasks;
using CitasMedicas.Infrastructure.Repository;
using System.CodeDom;
using System.Configuration;

namespace CitasMedicas.Infrastructure.Messaging
{
    public class RabbitMQProduce
    {
        private const string QueueName = "recetas_queueSet";
        private const string ExchangeName = "recetas_exchange";
        private readonly IConnectionFactory _connectionFactory;

        // 🔹 Inyectamos IConnectionFactory desde el contenedor
        public RabbitMQProduce(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task PublicarMensaje(object message)
        {
            try
            {
                var connection = await _connectionFactory.CreateConnectionAsync();
                var channel = await connection.CreateChannelAsync();

                await channel.ExchangeDeclareAsync(ExchangeName, ExchangeType.Fanout, durable: true);
                await channel.QueueDeclareAsync(QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                await channel.QueueBindAsync(QueueName, ExchangeName, "");

                var jsonMessage = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(jsonMessage);

                await channel.BasicPublishAsync(exchange: ExchangeName, routingKey: "", body: body);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en RabbitMQProduce: {e.Message}");
            }
        }
    }
}
