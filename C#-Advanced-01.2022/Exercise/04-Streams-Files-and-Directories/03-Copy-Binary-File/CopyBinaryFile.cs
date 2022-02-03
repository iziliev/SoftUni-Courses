using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            var inputFilePath = @"..\..\..\copyMe.png";
            var outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);

        }
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream fr = new FileStream(inputFilePath,FileMode.Open);
            using FileStream fw = new FileStream(outputFilePath,FileMode.OpenOrCreate);

            var buffer = new byte[1024];

            while (true)
            {
                var currentByte = fr.Read(buffer, 0, buffer.Length);

                if (currentByte == 0)
                {
                    break;
                }
                fw.Write(buffer, 0, currentByte);
            }
        }
    }
}
