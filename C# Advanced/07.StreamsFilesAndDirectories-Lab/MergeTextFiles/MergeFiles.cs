namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] textOne = File.ReadAllLines(firstInputFilePath);
            string[] textTwo = File.ReadAllLines(secondInputFilePath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                if (textOne.Length <= textTwo.Length)
                {
                    for (int i = 0; i < textOne.Length; i++)
                    {
                        writer.WriteLine(textOne[i]);
                        writer.WriteLine(textTwo[i]);
                    }
                    for (int i = textOne.Length; i < textTwo.Length; i++)
                    {
                        writer.WriteLine(textTwo[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < textTwo.Length; i++)
                    {
                        writer.WriteLine(textOne[i]);
                        writer.WriteLine(textTwo[i]);
                    }
                    for (int i = textTwo.Length; i < textOne.Length; i++)
                    {
                        writer.WriteLine(textOne[i]);
                    }
                }
            }
        }
    }
}