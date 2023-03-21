using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Common
{
    public static class ErrorMessages
    {
        public const string InvalidCommandType =
            "Provided type {0} does not exist or does not implement ICommand interface";
    }
}
