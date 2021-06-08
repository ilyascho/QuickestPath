using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public static class Helpers
    {
        public static void ShowKeyValuePairs<T>(this Dictionary<T, HashSet<T>> collection, string keyName, string valueName) 
        {
            foreach (T key in collection.Keys)
            {
                string values = String.Join(", ", collection[key]);
                Console.WriteLine($"{keyName} {key}    {valueName}: [{values}]");
            }
        }
    }
}
