using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        public string RandomString()
        {
            var random = new Random();

            if (this.Count>0)
            {
                var randomIndex = random.Next(0, this.Count);
                var item = this[randomIndex];
                this.Remove(item);
                return item;
            }
            return "No elements";
            
        }
    }
}
