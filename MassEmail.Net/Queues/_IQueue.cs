using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.Queues
{
    public interface IQueue
    {
        void SendToQueue(ICollection<string> listEmail);

        string GetFromQueue();

        void RemoveFromQueue(string email);
    }
}
