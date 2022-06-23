using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Sum_of_Integers
{
    public class Element : IElement
    {
        private string item;

        public Element(string item)
        {
            this.Item = item;
        }

        public string Item 
        { 
            get => item;
            private set
            {
                if (!int.TryParse(value,out int result))
                {
                    if (!value.All(x=>char.IsDigit(x)))
                    {
                        throw new FormatException($"The element '{value}' is in wrong format!");
                    }
                    throw new OverflowException($"The element '{value}' is out of range!");
                }
                
                item = value;
            } 
        }
    }
}
