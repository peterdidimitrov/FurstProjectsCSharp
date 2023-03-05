using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models.Interfaces
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (IsNumberValid(number))
            {
                return $"Dialing... {number}";
            }
            throw new ArgumentException("Invalid number!");
        }
            public bool IsNumberValid(string number)
        => number.All(x => char.IsDigit(x));
    }
}
