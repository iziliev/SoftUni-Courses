using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Files
{
    class Directory
    {
        public string Folder { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

        public Directory(string folder, string filename, long fileSize)
        {
            Folder = folder;
            FileName = filename;
            FileSize = fileSize;
        }
    }

    class Files
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<Directory>> data = new Dictionary<string, List<Directory>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("\\;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string fileDirectory = "";
                string folder = "";
                string filename = "";
                long fileSize = 0;

                if (input.Length > 4)
                {
                    fileDirectory = input[0];
                    folder = input[input.Length - 3];
                    filename = input[input.Length - 2];
                    fileSize = long.Parse(input[input.Length - 1]);
                }
                else if (input.Length == 4)
                {
                    fileDirectory = input[0];
                    folder = input[1];
                    filename = input[2];
                    fileSize = long.Parse(input[3]);
                }
                else
                {

                    fileDirectory = input[0];
                    filename = input[1];
                    fileSize = long.Parse(input[2]);
                }

                Directory directory = new Directory(folder, filename, fileSize);

                if (!data.ContainsKey(fileDirectory))
                {
                    data.Add(fileDirectory, new List<Directory>());
                }

                data[fileDirectory].Add(directory);

            }

            string[] searchDocs = Console.ReadLine()
                .Split(' ');
            bool check = false;

            foreach (var item in data)
            {
                if (item.Key == searchDocs[searchDocs.Length - 1])
                {
                    foreach (var items in item.Value.OrderByDescending(x=>x.FileSize).ThenBy(y=>y.FileName))
                    {
                        if (items.FileName.Contains($".{searchDocs[0]}"))
                        {
                            Console.WriteLine($"{items.FileName} - {items.FileSize} KB");
                            check = true;
                        }
                    }
                }
                    
            }
            if (check == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
