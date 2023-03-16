using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEmail.Net.Store
{
    internal class Excel : IStore
    {
        public ICollection<string> GetEmails()
        {
            ICollection<string> result = GenerateEmail();

            return result;
        }

        public static ICollection<string> GenerateEmail()
        {
            int counter = 0;
            ICollection<string> result = new HashSet<string>();

            do
            {
                result.Add(counter.ToString() + "@gmail.com");
                counter++;

            } while (counter < 8);

            return result;
        }
    }
}
