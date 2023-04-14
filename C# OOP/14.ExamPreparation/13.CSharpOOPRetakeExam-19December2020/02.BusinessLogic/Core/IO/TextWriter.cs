using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
    public class TextWriter : IWriter
    {
        string path = "../../../output.txt";
        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
        public void Write(string message)
        {
            using(StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(message);
            }
        }
    }
}
