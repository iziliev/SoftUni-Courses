using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        public static void Main()
        {
            string binaryFilePath = @"..\..\..\example.png";
            string bytesFilePath = @"..\..\..\bytes.txt";
            string outputPath = @"..\..\..\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using FileStream fs = new FileStream(binaryFilePath, FileMode.Open);
            using StreamReader sr = new StreamReader(bytesFilePath);
            using FileStream fw = new FileStream(outputPath, FileMode.OpenOrCreate);

            var list = new List<byte>();

            while (!sr.EndOfStream)
            {
                list.Add(byte.Parse(sr.ReadLine()));
            }

            var buffer = new byte[1024];

            while (true)
            {
                var currentByte = fs.Read(buffer, 0, buffer.Length);

                if (currentByte == 0)
                {
                    break;
                }

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (list.Contains(buffer[i]))
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (buffer[i] == list[j])
                            {
                                fw.Write(buffer, i, 1);
                            }
                        }
                    }
                }
            }

        }

    }
}
