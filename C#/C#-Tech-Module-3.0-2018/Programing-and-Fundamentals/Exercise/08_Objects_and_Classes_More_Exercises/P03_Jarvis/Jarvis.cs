using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Jarvis
{
    class Head
    {
        public int Energy { get; set; }
        public int Iq { get; set; }
        public string SkinMaterial { get; set; }

        public Head(int energy, int iq, string skinMaterial)
        {
            Energy = energy;
            Iq = iq;
            SkinMaterial = skinMaterial;
        }
    }

    class Torso
    {
        public int Energy { get; set; }
        public double ProcessorSize { get; set; }
        public string HousingMaterial { get; set; }

        public Torso(int energy, double processorSize, string housingMaterial)
        {
            Energy = energy;
            ProcessorSize = processorSize;
            HousingMaterial = housingMaterial;
        }
    }

    class Legs
    {
        public int Energy { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }

        public Legs(int energy, int strenght, int speed)
        {
            Energy = energy;
            Strenght = strenght;
            Speed = speed;
        }
    }

    class Arms
    {
        public int Energy { get; set; }
        public int ReachDistance { get; set; }
        public int Fingers { get; set; }

        public Arms(int energy, int reachDistance, int fingers)
        {
            Energy = energy;
            ReachDistance = reachDistance;
            Fingers = fingers;
        }
    }

    class Jarvis
    {
        static void Main()
        {
            long maxEnergy = long.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            List<Head> heads = new List<Head>();
            List<Torso> torsos = new List<Torso>();
            List<Arms> arms = new List<Arms>();
            List<Legs> legs = new List<Legs>();

            while (input != "Assemble!")
            {
                string[] commands = input
                    .Split(' ');
                
                if (commands[0] == "Head")
                {
                    int energy = int.Parse(commands[1]);
                    int iq = int.Parse(commands[2]);
                    string skinMaterial = commands[3];

                    Head head = new Head(energy, iq, skinMaterial);

                    heads.Add(head);
                }

                if (commands[0] == "Torso")
                {
                    int energy = int.Parse(commands[1]);
                    double processorSize = double.Parse(commands[2]);
                    string housingMaterial = commands[3];

                    Torso torso = new Torso(energy, processorSize, housingMaterial);
                    torsos.Add(torso);
                }

                if (commands[0] == "Arm")
                {
                    int energy = int.Parse(commands[1]);
                    int reachDistance = int.Parse(commands[2]);
                    int fingers = int.Parse(commands[3]);

                    Arms arm = new Arms(energy, reachDistance, fingers);
                    arms.Add(arm);
                }

                if (commands[0] == "Leg")
                {
                    int energy = int.Parse(commands[1]);
                    int strenght = int.Parse(commands[2]);
                    int speed = int.Parse(commands[3]);

                    Legs leg = new Legs(energy, strenght, speed);
                    legs.Add(leg);
                }

                input = Console.ReadLine();
            }


            if (heads.Count == 0 || 
                torsos.Count == 0 ||
                arms.Count < 2 ||
                legs.Count < 2)
            {
                Console.WriteLine($"We need more parts!");
            }
            else
            {
                var minHeadEnergy = heads.OrderBy(y => y.Energy).Select(x=>x.Energy).Take(1).ToArray();
                var minTorsoEnergy = torsos.OrderBy(y => y.Energy).Select(x => x.Energy).Take(1).ToArray();
                var minArmEnergyLeft = arms.OrderBy(y => y.Energy).Select(x => x.Energy).Take(1).ToArray();
                var minArmEnergyRight = arms.OrderBy(y => y.Energy).Select(x => x.Energy).Skip(1).Take(1).ToArray();
                var minLegEnergyLeft = legs.OrderBy(y => y.Energy).Select(x => x.Energy).Take(1).ToArray();
                var minLegEnergyRight = legs.OrderBy(y => y.Energy).Select(x => x.Energy).Skip(1).Take(2).ToArray();

                long sum = minHeadEnergy[0] + minTorsoEnergy[0] + minArmEnergyLeft[0] + minArmEnergyRight[0] + minLegEnergyLeft[0] + minLegEnergyRight[0];

                if (sum > maxEnergy)
                {
                    Console.WriteLine("We need more power!");
                }
                else
                {
                    Console.WriteLine("Jarvis:");
                    
                    foreach (var item in heads.OrderBy(x=>x.Energy).Take(1))
                    {
                        Console.WriteLine("#Head:");
                        Console.WriteLine($"###Energy consumption: {item.Energy}");
                        Console.WriteLine($"###IQ: {item.Iq}");
                        Console.WriteLine($"###Skin material: {item.SkinMaterial}");

                    }
                    foreach (var item in torsos.OrderBy(x=>x.Energy).Take(1))
                    {
                        Console.WriteLine("#Torso:");
                        Console.WriteLine($"###Energy consumption: {item.Energy}");
                        Console.WriteLine($"###Processor size: {item.ProcessorSize:F1}");
                        Console.WriteLine($"###Corpus material: {item.HousingMaterial}");
                    }
                    foreach (var item in arms.OrderBy(x => x.Energy).Take(1))
                    {
                        Console.WriteLine("#Arm:");
                        Console.WriteLine($"###Energy consumption: {item.Energy}");
                        Console.WriteLine($"###Reach: {item.ReachDistance}");
                        Console.WriteLine($"###Fingers: {item.Fingers}");
                    }
                    foreach (var item in arms.OrderBy(x => x.Energy).Skip(1).Take(1))
                    {
                        Console.WriteLine("#Arm:");
                        Console.WriteLine($"###Energy consumption: {item.Energy}");
                        Console.WriteLine($"###Reach: {item.ReachDistance}");
                        Console.WriteLine($"###Fingers: {item.Fingers}");
                    }
                    foreach (var item in legs.OrderBy(x => x.Energy).Take(1))
                    {
                        Console.WriteLine("#Leg:");
                        Console.WriteLine($"###Energy consumption: {item.Energy}");
                        Console.WriteLine($"###Strength: {item.Strenght}");
                        Console.WriteLine($"###Speed: {item.Speed}");
                    }
                    foreach (var item in legs.OrderBy(x => x.Energy).Skip(1).Take(1))
                    {
                        Console.WriteLine("#Leg:");
                        Console.WriteLine($"###Energy consumption: {item.Energy}");
                        Console.WriteLine($"###Strength: {item.Strenght}");
                        Console.WriteLine($"###Speed: {item.Speed}");
                    }
                }
            }
        }
    }
}
