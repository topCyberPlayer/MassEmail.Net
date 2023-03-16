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
        string Name { get; }

        EmailSendingResult Send(EmailMessage message, string emailTo);
    }
}
