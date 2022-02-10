using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace P09_Use_Your_Chains_Buddy
{
    class Use_Your_Chains_Buddy
    {
        static void Main()
        {
            string pattern = @"<p>(.+?\n)<\/p>";
            string text = @"<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>";
            //string text = Console.ReadLine();
                            
            var matches = Regex.Matches(text,pattern);
            
            string[] match = new string[matches.Count];
            
            int count = 0;
            foreach (Match item in matches)
            {
                match[count] = item.Groups[1].ToString();
                count++;
            }
            
            string takePattern = @"(\w+)";
            
            List<string> takes = new List<string>();
            for (int i = 0; i < match.Length; i++)
            {
                Regex rgx = new Regex(takePattern);
            
                var mch = rgx.Matches(match[i]);
            
                foreach (Match item in mch)
                {
                    takes.Add(item.Groups[1].Value.ToString());
                }
            }
            
            List<string> result = new List<string>();
            
            for (int i = 0; i < takes.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                var strTake = takes[i];
                for (int j = 0; j < strTake.Length; j++)
                {
                    if (strTake[j] == 'a')
                    {
                        sb.Append('n');
                    }
                    else if (strTake[j] == 'b')
                    {
                        sb.Append('o');
                    }
                    else if (strTake[j] == 'c')
                    {
                        sb.Append('p');
                    }
                    else if (strTake[j] == 'd')
                    {
                        sb.Append('q');
                    }
                    else if (strTake[j] == 'e')
                    {
                        sb.Append('r');
                    }
                    else if (strTake[j] == 'f')
                    {
                        sb.Append('s');
                    }
                    else if (strTake[j] == 'g')
                    {
                        sb.Append('t');
                    }
                    else if (strTake[j] == 'h')
                    {
                        sb.Append('u');
                    }
                    else if (strTake[j] == 'i')
                    {
                        sb.Append('v');
                    }
                    else if (strTake[j] == 'j')
                    {
                        sb.Append('w');
                    }
                    else if (strTake[j] == 'k')
                    {
                        sb.Append('x');
                    }
                    else if (strTake[j] == 'l')
                    {
                        sb.Append('y');
                    }
                    else if (strTake[j] == 'm')
                    {
                        sb.Append('z');
                    }
                    else if (strTake[j] == 'n')
                    {
                        sb.Append('a'); 
                    }
                    else if (strTake[j] == 'o')
                    {
                        sb.Append('b');
                    }
                    else if (strTake[j] == 'p')
                    {
                        sb.Append('c');
                    }
                    else if (strTake[j] == 'q')
                    {
                        sb.Append('d');
                    }
                    else if (strTake[j] == 'r')
                    {
                        sb.Append('e');
                    }
                    else if (strTake[j] == 's')
                    {
                        sb.Append('f');
                    }
                    else if (strTake[j] == 't')
                    {
                        sb.Append('g');
                    }
                    else if (strTake[j] == 'u')
                    {
                        sb.Append('h');
                    }
                    else if (strTake[j] == 'v')
                    {
                        sb.Append('i');
                    }
                    else if (strTake[j] == 'w')
                    {
                        sb.Append('j');
                    }
                    else if (strTake[j] == 'x')
                    {
                        sb.Append('k');
                    }
                    else if (strTake[j] == 'y')
                    {
                        sb.Append('l');
                    }
                    else if (strTake[j] == 'z')
                    {
                        sb.Append('m');
                    }
                    else
                    {
                        sb.Append(strTake[j]);
                    }
                }
                result.Add(string.Concat(sb.ToString()));
            }
            
            Console.WriteLine(string.Join(" ",result));
            
        }
    }
}
