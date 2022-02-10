using System;
using System.Collections.Generic;

namespace P03_A_Miner_Task
{
    class A_Miner_Task
    {
        static void Main()
        {
            Dictionary<string, int> miner = new Dictionary<string, int>();

            string command = Console.ReadLine();

            int count = 1;
            List<string> nameMine = new List<string>();
            List<int> quantityMine = new List<int>();

            while (command != "stop")
            {
                if (count % 2 !=0 )
                {
                    nameMine.Add(command);
                }
                else
                {
                    int quantity = int.Parse(command);
                    quantityMine.Add(quantity);
                }
                count++;
                command = Console.ReadLine();
            }

            for (int i = 0; i < nameMine.Count; i++)
            {
                if (!miner.ContainsKey(nameMine[i]))
                {
                    miner.Add(nameMine[i], quantityMine[i]);
                }
                else
                {
                    miner[nameMine[i]] += quantityMine[i];
                }
            }

            foreach (var item in miner)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
