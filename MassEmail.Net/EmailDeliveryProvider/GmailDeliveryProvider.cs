using System.Net;
using System.Net.Mail;
using MassEmail.Net.Model.Result;

namespace MassEmail.Net.EmailDeliveryProvider
{
    public class GmailDeliveryProvider : IEmailDeliveryProvider
    {
        public string Name 
        {  
            get 
            { 
                return "GMail"; 
            } 
        }

        public EmailSendingResult Send(EmailMessage message, string emailTo)
        {
            EmailSendingResult result = default;// = new EmailSendingResult();

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(message.From),
                Subject = message.Subject,
                Body = message.PlainTextBody,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(emailTo);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true,
            };

            try
            {
                //smtpClient.Send(mailMessage);
                Console.WriteLine($"Сообщение отправлено пользователю: {emailTo}");
                result = new EmailSendingResult(true);

            }
            catch (Exception ex)
            {
                result = new EmailSendingResult(false, ex.Message);
            }

            return result;
        }
    }
}
