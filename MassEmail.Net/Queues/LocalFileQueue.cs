using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.Queues
{
    internal class LocalFileQueue : IQueue
    {
        public void SendToQueue(ICollection<string> listEmail)
        {
            foreach (string email in listEmail)
            {
                SendToQueue(email);
            }
        }

        private void SendToQueue(string email)
        {

        }

        public string GetFromQueue()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromQueue(string email)
        {
            throw new NotImplementedException();
        }
    }
}
