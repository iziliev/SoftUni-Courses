using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using _07_Military_Elite.Models;
using System;
using System.Collections.Generic;

namespace _07_Military_Elite
{
    public class StartUp
    {
        public static void Main()
        {
            var soldiers = new Dictionary<int,ISoldier>();

            var input = string.Empty;
            while ((input = Console.ReadLine())!="End")
            {
                var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (args[0]=="Private")
                {
                    var @private = new Private(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]));
                    soldiers.Add(int.Parse(args[1]),@private);
                }
                else if (args[0] == "LieutenantGeneral")
                {
                    var @private = new LieutenantGeneral(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]));

                    for (int i = 5; i < args.Length; i++)
                    {
                        var privateId = int.Parse(args[i]);
                        var currentPrivate = (IPrivate)soldiers[privateId];
                        @private.Privates.Add(currentPrivate);
                    }
                    soldiers.Add(int.Parse(args[1]),@private);
                }
                else if (args[0] == "Engineer")
                {
                    var IsCorrectCorp = Enum.TryParse(args[5], out Corps result);
                    if (IsCorrectCorp)
                    {
                        var engeneer = new Engineer(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]), result);
                        for (int i = 6; i < args.Length; i+=2)
                        {
                            var repair = new Repair(args[i], int.Parse(args[i + 1]));
                            engeneer.Repairs.Add(repair);
                        }

                        soldiers.Add(int.Parse(args[1]), engeneer);
                    }
                }
                else if (args[0] == "Commando")
                {
                    var IsCorrectCorp = Enum.TryParse(args[5], out Corps result);

                    if (IsCorrectCorp)
                    {
                        var comando = new Comando(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]), result);

                        for (int i = 6; i < args.Length; i += 2)
                        {
                            var IsCorrectState = Enum.TryParse(args[i + 1], out State results);

                            if (IsCorrectState)
                            {
                                var mission = new Mission(args[i], results);
                                comando.AddMission(mission);
                            }
                        }
                        soldiers.Add(int.Parse(args[1]), comando);
                    }
                    
                }
                else if (args[0] == "Spy")
                {
                    var spy = new Spy(int.Parse(args[1]), args[2], args[3], int.Parse(args[4]));
                    soldiers.Add(int.Parse(args[1]),spy);
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value);
            }
        }
    }
}
