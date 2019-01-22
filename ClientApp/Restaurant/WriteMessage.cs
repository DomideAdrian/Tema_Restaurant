using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class WriteMessage
    {
        public string WeldPhrase(string flag, List<string> weldWord)
        {
            string message = flag + ";";
            foreach(var element in weldWord)
            {
                message = message + element + ";";
            }
            return message;
        }
    }
}
