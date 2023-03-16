using MassEmail.Net.EmailDeliveryProvider;
using MassEmail.Net.Queues;

namespace MassEmail.Net.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new ProcessEmails().Start();
        }
    }

    public class ProcessEmails
    {
        public void Start()
        {
            IQueue queue = new RabbitMqQueue();

            MassEmail.Net.Model.ProcessEmails publisher = new MassEmail.Net.Model.ProcessEmails();

            string email = publisher.GetFromQueue(queue);

            publisher.SendEmail(queue, new GmailDeliveryProvider(), email);
        }
    }
}