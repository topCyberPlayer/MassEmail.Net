using MassEmail.Net.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.EmailDeliveryProvider
{
    public interface IEmailDeliveryProvider
    {
        /// <summary>
        /// Возвращает название Службы доставки писем
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Отправлет письма
        /// </summary>
        /// <param name="message"></param>
        /// <param name="emailTo"></param>
        /// <returns></returns>
        EmailSendingResult Send(EmailMessage message, string emailTo);
    }
}
