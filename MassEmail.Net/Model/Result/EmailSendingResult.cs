using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.Model.Result
{
    public class EmailSendingResult
    {
        public bool IsSuccess { get; }

        public string ErrorDescription { get; }

        public EmailSendingResult(bool isSuccess, string errorDescription = null)
        {
            IsSuccess = isSuccess;
            ErrorDescription = errorDescription;
        }
    }
}
