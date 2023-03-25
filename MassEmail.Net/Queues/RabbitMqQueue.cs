using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Text;

namespace MassEmail.Net.Queues
{
    public class RabbitMqQueue : IQueue
    {
        const string nameQueue = "EmailQueue";

        public void SendToQueue(ICollection<string> listEmail)
        {
            foreach (string email in listEmail)
            {
                SendToQueue(email);
            }
        }

        private void SendToQueue(string email)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: nameQueue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                arguments: null);

                var body = Encoding.UTF8.GetBytes(email);

                channel.BasicPublish(exchange: "",
                                    routingKey: nameQueue,
                                    basicProperties: null,
                                    body: body);
            }
        }

        public string GetFromQueue()
        {
            string message = default;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: nameQueue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, ea) =>
                {
                    var body = ea.Body;
                    message = Encoding.UTF8.GetString(body.ToArray());

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                channel.BasicConsume(queue: nameQueue,
                                     autoAck: false,
                                     consumer: consumer);
                
            }

            return message;
        }

        public void RemoveFromQueue(string email)
        {
            //Необходимо реализовать логику удаления сообщения из очереди RabbitMQ при ручном удалении
        }
    }
}
