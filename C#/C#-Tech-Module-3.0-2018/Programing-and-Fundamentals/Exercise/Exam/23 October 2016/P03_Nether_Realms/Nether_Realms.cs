using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P03_Nether_Realms
{
    class Demon
    {
        public int Health { get; set; }
        public double Damage { get; set; }

        public Demon(int health,double damage)
        {
            Health = health;
            Damage = damage;
        }
    }

    class Nether_Realms
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string damagePattern = @"[-|+]*[\d+]\.*[\d+]*";
            string healthPattern = @"[A-Za-z]+";
            string delitel = @"[\*]+|[\/]+";

            var regexDamage = new Regex(damagePattern);
            var regexHealth = new Regex(healthPattern);
            var regexDelitel = new Regex(delitel);
            SortedDictionary<string, Demon> data = new SortedDictionary<string, Demon>();

            for (int i = 0; i < input.Length; i++)
            {
                var matchDamage = regexDamage.Matches(input[i]);
                var matchHealth = regexHealth.Matches(input[i]);
                var matchDelitel = regexDelitel.Matches(input[i]);

                List<string> listDamage = new List<string>();
                //List<string> listHealth = new List<string>();
                //List<string> listDelitel = new List<string>();

                string strName = "";
                string operat = "";

                foreach (Match item in matchDamage)
                {
                    listDamage.Add(item.Value.ToString());
                }
                foreach (Match item in matchHealth)
                {
                    strName += item.Value.ToString();
                }
                foreach (Match item in matchDelitel)
                {
                    operat += item.Value.ToString();
                }

                int health = 0;

                for (int j = 0; j < strName.Length; j++)
                {
                    health += strName[j];
                }

                double damage = 0.00;

                for (int j = 0; j < listDamage.Count; j++)
                {
                    damage += double.Parse(listDamage[j]);
                }

                for (int j = 0; j < operat.Length; j++)
                {
                    if (operat[j] == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                Demon demons = new Demon(health, damage);

                if (!data.ContainsKey(input[i]))
                {
                    data.Add(input[i], demons);
                }
            }

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Health} health, {item.Value.Damage:f2} damage");
            }
        }
    }
}
