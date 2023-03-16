using MassEmail.Net.EmailDeliveryProvider;
using MassEmail.Net.Model.Result;
using MassEmail.Net.Queues;
using MassEmail.Net.Store;

namespace MassEmail.Net.Model
{
    public class ProcessEmails
    {
        public void Start()
        {
            Console.WriteLine("Seee");

            IQueue queue = new RabbitMqQueue();

            ICollection<string> listEmail = GetEmails(new Excel());

            UploadToQueue(queue, listEmail);

            string email = GetFromQueue(queue);

            SendEmail(queue, new GmailDeliveryProvider(), email);
        }

        private ICollection<string> GetEmails(IStore store)
        {
            ICollection<string> _listEmail = store.GetEmails();

            return _listEmail;
        }

        private void UploadToQueue(IQueue queue, ICollection<string> listEmail)
        {
            queue.SendToQueue(listEmail);
        }


        public string GetFromQueue(IQueue queue)
        {
            string email = queue.GetFromQueue();

            return email;
        }

        public void SendEmail(IQueue queue, IEmailDeliveryProvider emailDeliveryProvider, string email)
        {
            EmailSendingResult result = emailDeliveryProvider.Send(CreateEmailMessage(), email);

            if (result.IsSuccess)
            {
                queue.RemoveFromQueue(email);
            }
        }

        private EmailMessage CreateEmailMessage()
        {
            EmailMessage message = new EmailMessage()
            {
                From = "abc@ya.ru",
                Subject = "Запущена новая служба",
                PlainTextBody = "Поздравляем!\nВы стали первыми, кто узнал о запуке нашей новой службе рассылок эл.писем"
            };

            return message;
        }
    }
}
