using System;
using Newtonsoft.Json;
using MessageProducerService.Models;
using RabbitMQ.Client;
using System.Text;

namespace MessageProducerService.Repository
{
    public class RabbitMQMessageProducer : IMessageProducer
    {
        public bool ProduceMessage(Message msg)
        {

            string jsonMsg = JsonConvert.SerializeObject(msg);

            IEncryptor encryptor = EncryptorFactory.CreateNewEncryptor();
            string encryptedMsg = encryptor.EncryptMessage(jsonMsg);

            try
            {
                // Creating the RabbitMQ connection factory object with default configurations:
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "NatanMeirov",
                    Password = "123456",
                    VirtualHost = ConnectionFactory.DefaultVHost,
                    Port = AmqpTcpEndpoint.UseDefaultPort
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "MicroservicesMessages",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var bodyOfMessage = Encoding.UTF8.GetBytes(encryptedMsg);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "MicroservicesMessages",
                                         basicProperties: null,
                                         body: bodyOfMessage);

                    Console.WriteLine(" [x] Sent {0}, \n(Encrypted:) {1}", jsonMsg, bodyOfMessage);

                    return true;
                }
            }
            catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
