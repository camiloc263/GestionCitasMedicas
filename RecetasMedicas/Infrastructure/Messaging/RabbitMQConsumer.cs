using RabbitMQ.Client;
using RecetasMedicas.Application.Services;
using System;
using Newtonsoft.Json;
using System.Text;
using RecetasMedicas.Domain.Entities;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using System.Threading.Channels;
using RecetasMedicas.Infrastructure.Repository;
using RecetasMedicas.Domain.Interfaces;
using System.Runtime.Remoting.Channels;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration;
using System.Linq;

namespace RecetasMedicas.Infrastructure.Messaging
{
    public class RabbitMQConsumer
    {
       private const string QueueName = "recetas_queue";
        private const string ExchangeName = "recetas_exchange";
        private readonly IFormulaMedicaServices _formulaMedicaServices;


        public RabbitMQConsumer(IFormulaMedicaServices formulaMedicaServices)
        {
            _formulaMedicaServices = formulaMedicaServices;
        }

        public async Task Escuchar()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = await factory.CreateConnectionAsync())
            using (var channel = await connection.CreateChannelAsync())
            {
                await channel.ExchangeDeclareAsync(ExchangeName, ExchangeType.Fanout, durable: true);
                await channel.QueueDeclareAsync(QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                await channel.QueueBindAsync(QueueName, ExchangeName, "");

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"[✔] Mensaje recibido: {message}");

                    try
                    {
                        // Deserializa el mensaje y procesa la receta médica
                        var receta = JsonConvert.DeserializeObject<FormulaMedica>(message);
                        await _formulaMedicaServices.AddFormulaMedicaAsync(receta);
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[❌] Error al procesar el mensaje: {ex.Message}");
                    }
                };

                await channel.BasicConsumeAsync(queue: QueueName, autoAck: true, consumer: consumer);

               
                await Task.Delay(-1); // Mantiene el proceso en ejecución
            }
        }


    }
    }

        



                    
        

                      

            
