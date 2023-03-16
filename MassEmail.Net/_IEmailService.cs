using MassEmail.Net.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net
{
    internal interface IEmailService
    {
        EmailSendingResult Send(EmailMessage message);
    }
}
