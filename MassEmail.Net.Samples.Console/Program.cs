using MassEmail.Net.Model;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace MassEmail.Net.Samples.Console
{


    internal class Program
    {
        static void Main(string[] args)
        {
            //new Program().UsingSmtpClient();
            //new Program().UsingMailKit();

            new ProcessEmails().Start();
        }

        private void UsingSmtpClient()
        {
            // 1- we need to define our server connection configuration.
            var host = "smtp.gmail.com";
            var port = 587;
            var credentials = new NetworkCredential("kgbtoplayer@gmail.com", "pat%n!qgsu8E");

            // 2- create the SmtpClient instance, and set the server connection configuration.
            using System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                Credentials = credentials,
            };

            // 3- create the email message
            MailMessage emailMessage = new MailMessage
            {
                From = new MailAddress("kgbtoplayer@gmail.com"),
                Subject = "Проверка работоспобосности службы отправки email",
                Body = "Привет! Если ты получил это сообщение, значит служба работает",
                IsBodyHtml = false,
            };

            emailMessage.To.Add(new MailAddress("ton4ik07@yandex.ru"));

            // 4- send the email message using the smtp client
            smtpClient.Send(emailMessage);
        }

        private void UsingMailKit()
        {
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress("from name", "kgbtoplayer@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("to name", "ton4ik07@yandex.ru"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Hello"
            };

            using (MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("kgbtoplayer@gmail.com", "pat%n!qgsu8E");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}