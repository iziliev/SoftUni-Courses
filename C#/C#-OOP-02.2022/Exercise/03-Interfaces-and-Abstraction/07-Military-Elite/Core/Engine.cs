using _07_Military_Elite.Contracts;
using _07_Military_Elite.Enums;
using _07_Military_Elite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Core
{
    public class Engine
    {
        Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

        public void Run()
        {
            var input =string.Empty;
            while ((input=Console.ReadLine())!="End")
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[1]);
                var firstName = args[2];
                var lastname = args[3];

                if (args[0]=="Private")
                {
                    IPrivate @private = new Private(id, firstName, lastname,decimal.Parse(args[4]));
                    soldiers.Add(id, @private);
                }
                else if (args[0] == "LieutenantGeneral")
                {
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id,firstName,lastname, decimal.Parse(args[4]));

                    for (int i = 5; i < args.Length; i++)
                    {
                        var @private = (Private)soldiers[int.Parse(args[i])];
                        lieutenantGeneral.Privates.Add(@private);
                    }
                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (args[0] == "Engineer")
                {
                    var isCorps = Enum.TryParse(args[5], out Corps result);

                    if (isCorps)
                    {
                        IEngineer engineer = new Engineer(id, firstName,lastname,decimal.Parse(args[4]),result);

                        for (int i = 6; i < args.Length; i+=2)
                        {
                            IRepair repair = new Repair(args[i], int.Parse(args[i + 1]));
                            engineer.Repairs.Add(repair);
                        }

                        soldiers.Add(id, engineer);
                    }
                }
                else if (args[0] == "Commando")
                {
                    var isCorps = Enum.TryParse(args[5], out Corps result);

                    if (isCorps)
                    {
                        ICommando comando = new Commando(id, firstName, lastname, decimal.Parse(args[4]), result);

                        for (int i = 6; i < args.Length; i+=2)
                        {
                            var isCorrectMission = Enum.TryParse(args[i + 1], out States state);
                            if (isCorrectMission)
                            {
                                IMission mission = new Mission(args[i], state);
                                comando.Missions.Add(mission);
                            }
                        }
                        soldiers.Add(id, comando);
                    }
                }
                else if (args[0] == "Spy")
                {
                    ISpy spy = new Spy(id, firstName, lastname, args[4]);
                    soldiers.Add(id, spy);
                }
            }

            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
