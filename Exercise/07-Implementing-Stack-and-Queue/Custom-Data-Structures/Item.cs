using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    class Item
    {
        public Item(int value)
        {
            this.Value = value;
        }
        public Item Next { get; set; }
        public Item Pevious { get; set; }
        public int Value { get; set; }
    }
}
