using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString(List<string> list)
        {
            Random random = new Random();
            int index = random.Next(0, list.Count);
            string str = list[index];
            
            list.RemoveAt(index);
            
            return str;
        }
    }
}
