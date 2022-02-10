using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        public static void Main()
        {
            var inputFilePath = @"..\..\..\input";
            var zipArchiveFilePath = @"..\..\..\archive.zip";
            var outputFilePath = @"..\..\..\extracted";
            var fileName = "extracted.png";

            ZipFileToArchive(inputFilePath, zipArchiveFilePath);

            ExtractFileFromArchive(zipArchiveFilePath, fileName, outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))
            {
                File.Delete(zipArchiveFilePath);
            }

            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            if (File.Exists(fileName))
            {
                File.Delete(outputFilePath);
            }

            ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath, true);

            var ffff = Directory.GetFiles(outputFilePath, ".");
            var oldName = string.Empty;

            foreach (var item in ffff)
            {
                var info = new FileInfo(item);
                oldName = info.Name;
                break;
            }

            var old  = @"..\..\..\extracted\" + oldName;
            var newN = @"..\..\..\extracted\" + fileName;

            File.Copy(old, newN, true);
            File.Delete(old);
        }

    }
}
