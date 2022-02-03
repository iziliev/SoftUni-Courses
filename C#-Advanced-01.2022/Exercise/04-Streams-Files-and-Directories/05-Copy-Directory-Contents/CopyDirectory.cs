using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        public static void Main()
        {
            Console.WriteLine("Please insert path for folder which you want to copy!");
            var inputPath = @$"{Console.ReadLine()}";
            Console.WriteLine("Please insert path where folder will paste!");
            var outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }
        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var dir = new DirectoryInfo(inputPath);
            var outDir = new DirectoryInfo(outputPath);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            var dirs = dir.GetDirectories();

            if (outDir.Exists)
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(outputPath, file.Name);
                file.CopyTo(targetFilePath);
            }
        }
    }
}
