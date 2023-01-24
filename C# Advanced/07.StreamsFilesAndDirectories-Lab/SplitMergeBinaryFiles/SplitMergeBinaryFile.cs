namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            int parts = 2;
            using (FileStream stream = new FileStream(sourceFilePath, FileMode.Open))
            {
                if (stream.Length % 2 == 0)
                {
                    long sizeOfPart = stream.Length / parts;
                    for (int i = 0; i < parts; i++)
                    {
                        using (FileStream partStream = new FileStream($@"..\..\..\Files\part-{i + 1}.bin", FileMode.OpenOrCreate))
                        {
                            byte[] buffer = new byte[sizeOfPart];
                            stream.Read(buffer, 0, (int)sizeOfPart);

                            partStream.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
                else
                {
                    long sizeOfFirstPart = stream.Length / parts + 1;
                    long sizeOfSecondPart = stream.Length / parts;

                    using (FileStream firstPartStream = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
                    {
                        byte[] buffer = new byte[sizeOfFirstPart];
                        stream.Read(buffer, 0, (int)sizeOfFirstPart);

                        firstPartStream.Write(buffer, 0, buffer.Length);
                    }
                    using (FileStream secondPartStream = new FileStream(partTwoFilePath, FileMode.OpenOrCreate))
                    {
                        byte[] buffer = new byte[sizeOfSecondPart];
                        stream.Read(buffer, 0, (int)sizeOfSecondPart);

                        secondPartStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream firstStream = new FileStream(partOneFilePath, FileMode.Open))
            {

                using (FileStream joinedStream = new FileStream(joinedFilePath, FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[firstStream.Length];
                    firstStream.Read(buffer, 0, (int)firstStream.Length);

                    joinedStream.Write(buffer, 0, buffer.Length);
                }
            }
            using (FileStream secondStream = new FileStream(partTwoFilePath, FileMode.Open))
            {

                using (FileStream joinedStream = new FileStream(joinedFilePath, FileMode.Append))
                {
                    byte[] buffer = new byte[secondStream.Length];
                    secondStream.Read(buffer, 0, (int)secondStream.Length);

                    joinedStream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}