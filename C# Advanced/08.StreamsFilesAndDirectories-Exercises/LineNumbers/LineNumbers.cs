﻿namespace LineNumbers
{

    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(char.IsLetter);
                int punctuacionCount = lines[i].Count(char.IsPunctuation);
                stringBuilder.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({punctuacionCount})");
            }
            
            File.WriteAllText(outputFilePath, stringBuilder.ToString());
        }
    }
}
