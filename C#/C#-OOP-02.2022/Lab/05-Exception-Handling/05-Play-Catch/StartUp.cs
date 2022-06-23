using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Play_Catch
{
    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var exCount = 0;

            while (exCount < 3)
            {
                var commandArgs = Console.ReadLine().Split(' ');

                var command = commandArgs[0];

                try
                {
                    if (command == "Replace")
                    {
                        if (int.TryParse(commandArgs[1], out int result) && int.TryParse(commandArgs[2], out int results))
                        {
                            if (IsInRange(array.Count - 1, result))
                            {
                                array[result] = results;
                            }
                            else
                            {
                                exCount++;
                                throw new IndexOutOfRangeException("The index does not exist!");
                            }
                            
                        }
                        else
                        {
                            exCount++;
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }
                    else if (command == "Show")
                    {
                        if (int.TryParse(commandArgs[1], out int result))
                        {

                            if (IsInRange(array.Count - 1, result))
                            {
                                Console.WriteLine(array[result]);
                            }
                            else
                            {
                                exCount++;
                                throw new IndexOutOfRangeException("The index does not exist!");
                            }
                        }
                        else
                        {
                            exCount++;
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }
                    else
                    {
                        if (int.TryParse(commandArgs[1], out int result) && int.TryParse(commandArgs[2], out int results))
                        {

                            if (IsInRange(array.Count - 1, result) && IsInRange(array.Count - 1, results))
                            {
                                var newList = array.GetRange(result, array.Count - result);
                                Console.WriteLine(String.Join(", ", newList));
                            }
                            else
                            {
                                exCount++;
                                throw new IndexOutOfRangeException("The index does not exist!");
                            }
                        }
                        else
                        {
                            exCount++;
                            throw new ArgumentException("The variable is not in the correct format!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Print(array);
        }

        private static void Print(List<int> array)
        {
            Console.WriteLine(String.Join(", ",array));
        }

        private static bool IsInRange(int arrayLenght, int index)
        {
            return index >= 0 && index <= arrayLenght;
        }
    }
}
