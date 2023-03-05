using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models.Interfaces
{
    public class Smartphone : ICallable, IBrowseble
    {
        public string Call(string number)
        {
            if (IsNumberValid(number))
            {
                return $"Calling... {number}";
            }
            throw new ArgumentException("Invalid number!");
        }
        public string Browse(string url)
        {
            if (!IsUrlValid(url))
            {
                return $"Browsing: {url}!";
            }
            throw new ArgumentException("Invalid URL!");
        }
        public bool IsNumberValid(string number)
            => number.All(x => char.IsDigit(x));
        public bool IsUrlValid (string url) 
            => url.Any(x => char.IsDigit(x));

    }
}
