using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models.ICallable
{
    public interface IBorn
    {
        string Name { get; }
        string Date { get; }
    }
}
