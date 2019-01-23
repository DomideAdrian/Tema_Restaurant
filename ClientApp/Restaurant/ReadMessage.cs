using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class ReadMessage
    {
        List<string> splits = new List<string>();
        public string SplitPhrase(string phraseToSplit, int index)
        {
            string[] words = phraseToSplit.Split(';');
            foreach(var word in words)
            {
                splits.Add(word);
            }
            return splits[index];
        }

        public string GetPhrase(string phrase)
        {
            return phrase;
        }
    }
}
