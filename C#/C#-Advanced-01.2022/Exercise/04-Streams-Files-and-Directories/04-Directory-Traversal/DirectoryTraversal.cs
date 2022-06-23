using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            var reportFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";
            var inputFolderPath = Directory.GetCurrentDirectory();
            
            string textContent = TraverseDirectory(inputFolderPath);

            WriteReportToDesktop(textContent, reportFileName);

        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var allFiles = Directory.GetFiles(inputFolderPath, ".");

            var groupFiles = new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in allFiles)
            {
                var fileInfo = new FileInfo(item);

                if (!groupFiles.ContainsKey(fileInfo.Extension))
                {
                    groupFiles[fileInfo.Extension] = new Dictionary<string, double>();
                }

                var size = (double)fileInfo.Length / 1024;

                groupFiles[fileInfo.Extension].Add(fileInfo.Name, size);
            }

            var sortedFiles = groupFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            var lines = new List<string>();

            foreach (var item in groupFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                lines.Add(item.Key);

                foreach (var file in item.Value)
                {
                    lines.Add($"--{file.Key} - {file.Value:F3}kb");
                }
            }
            var sb = new StringBuilder();

            foreach (var item in lines)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(reportFileName, textContent);
        }

    }
}
