using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.Model.Result
{
    public class EmailSendingResult
    {
        public bool IsSuccess { get; private set; }

        public string ErrorDescription { get; private set; }

        public EmailSendingResult(bool isSuccess, string errorDescription = null)
        {
            IsSuccess = isSuccess;
            ErrorDescription = errorDescription;
        }
    }
}
