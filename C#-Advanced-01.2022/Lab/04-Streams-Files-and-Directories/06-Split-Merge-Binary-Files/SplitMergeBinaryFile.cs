using System;
using System.IO;
using System.Text;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        public static void Main()
        {
            var sourceFilePath = @"..\..\..\example.png";
            var partOneFilePath = @"..\..\..\part-1.bin";
            var partTwoFilePath = @"..\..\..\part-2.bin";
            var joinedFilePath = @"..\..\..\example-joined.png";

            SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);

            MergeBinaryFiles(partOneFilePath, partTwoFilePath, joinedFilePath);
        }
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream fs = new FileStream(sourceFilePath, FileMode.OpenOrCreate);
            using BinaryWriter firstFileWriter = new BinaryWriter(File.OpenWrite(partOneFilePath));
            using BinaryWriter secondFileWriter = new BinaryWriter(File.OpenWrite(partTwoFilePath));

            var size = fs.Length;
            long firstPartSize = 0;
            long secondPartSize = 0;

            if (size % 2 == 0)
            {
                firstPartSize = size / 2;
                secondPartSize = size / 2;
            }
            else
            {
                firstPartSize = size / 2;
                secondPartSize = size - firstPartSize;
            }

            var countByte = 0;

            while (countByte < firstPartSize)
            {
                if (countByte + 1024 < firstPartSize)
                {
                    var buffer = new byte[1024];
                    fs.Read(buffer, 0, buffer.Length);
                    firstFileWriter.Write(buffer, 0, buffer.Length);
                    countByte += buffer.Length;
                }
                else
                {
                    var buffer = new byte[firstPartSize-countByte];
                    fs.Read(buffer, 0, buffer.Length);
                    firstFileWriter.Write(buffer, 0, buffer.Length);
                    countByte += buffer.Length;
                }
            }
            
            countByte = 0;

            while (countByte < secondPartSize)
            {
                if (countByte + 1024 < secondPartSize)
                {
                    var buffer = new byte[1024];
                    fs.Read(buffer, 0, buffer.Length);
                    secondFileWriter.Write(buffer, 0, buffer.Length);
                    countByte += buffer.Length;
                }
                else
                {
                    var buffer = new byte[secondPartSize - countByte];
                    fs.Read(buffer, 0, buffer.Length);
                    secondFileWriter.Write(buffer, 0, buffer.Length);
                    countByte += buffer.Length;
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using BinaryWriter bw = new BinaryWriter(File.OpenWrite(joinedFilePath));
            using BinaryReader brOne = new BinaryReader(File.OpenRead(partOneFilePath));
            using BinaryReader brTwo = new BinaryReader(File.OpenRead(partTwoFilePath));

            var buffer = new byte[1024];

            while (true)
            {
                var current = brOne.Read(buffer,0,buffer.Length);
                
                if (current==0)
                {
                    break;
                }

                bw.Write(buffer,0, current);
            }

            while (true)
            {
                var current = brTwo.Read(buffer, 0, buffer.Length);

                if (current == 0)
                {
                    break;
                }

                bw.Write(buffer, 0, current);
            }
        }
    }
}
