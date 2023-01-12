namespace _09.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var text = new StringBuilder(string.Empty);

            var undo = new Stack<string>();
            undo.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] commArg = Console.ReadLine()
                    .Split();

                string currComm = commArg[0];

                if (currComm == "1")
                {
                    text.Append(commArg[1]);
                    undo.Push(text.ToString());
                }
                else if (currComm == "2")
                {
                    int eraseCount = int.Parse(commArg[1]);
                    text.Remove(text.Length - eraseCount, eraseCount);
                    undo.Push(text.ToString());
                }
                else if (currComm == "3")
                {
                    int position = int.Parse(commArg[1]);
                    if (position >= 1 && position <= text.Length)
                    {
                        Console.WriteLine(text[position - 1]);
                    }
                }
                else if (currComm == "4")
                {
                    undo.Pop();
                    text.Clear();
                    text.Append(undo.Peek());
                }
            }
        }
    }
}