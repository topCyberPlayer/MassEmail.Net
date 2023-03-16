using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.Store
{
    public class SomeDb : IStore
    {
        public ICollection<string> GetEmails()
        {
            throw new NotImplementedException();
        }
    }
}
