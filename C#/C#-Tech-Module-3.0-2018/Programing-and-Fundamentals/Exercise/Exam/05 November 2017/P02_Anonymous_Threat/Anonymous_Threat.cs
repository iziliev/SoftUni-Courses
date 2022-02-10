using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Anonymous_Threat
{
    class Anonymous_Threat
    {
        static void Main()
        {
            List<string> data = Console.ReadLine()
                .Split(' ')
                .ToList();

            string input = Console.ReadLine();


            while (input != "3:1")
            {
                string[] inputs = input
                    .Split(' ');

                string command = inputs[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(inputs[1]);
                    int endIndex = int.Parse(inputs[2]);

                    if (startIndex < 0 || startIndex >= data.Count-1)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > data.Count-1 || endIndex < 0)
                    {
                        endIndex = data.Count-1;
                    }
                    string newStr=string.Empty;
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        newStr += string.Concat(data[i]);
                    }
                    data.RemoveRange(startIndex, endIndex+1 - startIndex);
                    data.Insert(startIndex, newStr);
                }

                else if (command == "divide")
                {
                    int index = int.Parse(inputs[1]);

                    int partitions = int.Parse(inputs[2]);

                    List<string> partitionsRezult = new List<string>();

                    List<char> divideStr = data[index].ToList();
                    
                    if (divideStr.Count % partitions == 0)
                    {
                        var part = divideStr.Count / partitions;
                        
                        while (divideStr.Count != 0)
                        {
                            int count = 0;
                            string dividStr = string.Empty;
                            while (count != part)
                            {
                                dividStr += divideStr[count].ToString();
                                count++;
                            }
                            partitionsRezult.Add(dividStr);
                            divideStr.RemoveRange(0, count);
                        }

                        data.RemoveAt(index);

                        for (int i = 0; i < partitionsRezult.Count; i++)
                        {
                            data.Insert(index + i, partitionsRezult[i]);
                        }
                        partitionsRezult.Clear();
                    }

                    else
                    {
                        int parts = divideStr.Count / partitions;
                        int lastparts = parts + divideStr.Count % partitions;
                        var countPart = 0;

                        while (countPart != partitions - 1)
                        {
                            int count = 0;
                            string dividStr = string.Empty;

                            while (count != parts)
                            {
                                for (int i = 0; i < parts; i++)
                                {
                                    dividStr += divideStr[i];
                                    count++;
                                }
                                partitionsRezult.Add(dividStr);
                                divideStr.RemoveRange(0, count);
                            }
                            countPart++;
                        }
                        

                        var str = string.Empty;

                        for (int i = 0; i < divideStr.Count; i++)
                        {
                            str += divideStr[i];
                        }
                        data.RemoveAt(index);
                        partitionsRezult.Add(str);

                        for (int i = 0; i < partitionsRezult.Count; i++)
                        {
                            data.Insert(index + i, partitionsRezult[i]);
                        }
                        partitionsRezult.Clear();
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",data));
        }
    }
}
