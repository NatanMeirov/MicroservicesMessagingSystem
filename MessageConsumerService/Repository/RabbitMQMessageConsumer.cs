using System;
using Newtonsoft.Json;
using MessageConsumerService.Models;
using RabbitMQ.Client;
using System.Linq;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageConsumerService.Repository
{
    public class RabbitMQMessageConsumer : IMessageConsumer
    {
        public bool ConsumeMessage(out Message msg)
        {
            IDecryptor decryptor = DecryptorFactory.CreateNewDecryptor();
            string decryptedJsonMsg = string.Empty;


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

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var bodyOfMessage = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(bodyOfMessage.ToArray());
                        decryptedJsonMsg = decryptor.DecryptMessage(message);
                    };

                    msg = JsonConvert.DeserializeObject<Message>(decryptedJsonMsg);
                    Console.WriteLine(" [x] Received {0}, \n(Decrypted:) {1}", decryptedJsonMsg, msg);

                    channel.BasicConsume(queue: "MicroservicesMessages",
                                         autoAck: true,
                                         consumer: consumer);

                    return true;
                }
            }
            catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException ex)
            {
                msg = null;
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
