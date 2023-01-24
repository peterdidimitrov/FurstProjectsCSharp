namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }
        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder outputText = new StringBuilder();

            StreamReader text = new StreamReader(inputFilePath);

            char[] symbols = { '-', ',', '.', '!', '?' };

            int count = 0;

            string line = string.Empty;
            while ((line = text.ReadLine()) != null)
            {
                if (count % 2 == 0)
                {
                    string reverse = ReverseString(line);

                    outputText.AppendLine(reverse);
                }
                count++;
            }
            ReplaseSymbols(outputText, symbols);
            return outputText.ToString();
        }
        private static string ReverseString(string line)
        {
            string[] reverseline = line.Split().Reverse().ToArray();
            return string.Join(" ", reverseline);
        }
        private static void ReplaseSymbols(StringBuilder outputText, char[] symbols)
        {
            for (int i = 0; i < outputText.Length; i++)
            {
                if (outputText[i] == symbols[0] || outputText[i] == symbols[1] ||
                    outputText[i] == symbols[2] || outputText[i] == symbols[3] ||
                    outputText[i] == symbols[4])
                {
                    outputText.Replace(outputText[i], '@');
                }
            }
        }
    }
}
