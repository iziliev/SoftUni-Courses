using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        public static void Main()
        {
            var folderPath = @"..\..\..\TestFolder";
            var outputFilePath = @"..\..\..\TestFolder\оutput.txt";

            GetFolderSize(folderPath, outputFilePath);
        }
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            using StreamWriter sw = new StreamWriter(outputFilePath);

            double sum = 0;

            var dir = new DirectoryInfo(folderPath);

            var infos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (var item in infos)
            {
                sum += item.Length;
            }

            sum = sum / 1024;
            
            sw.WriteLine(sum.ToString());
        }

    }
}
