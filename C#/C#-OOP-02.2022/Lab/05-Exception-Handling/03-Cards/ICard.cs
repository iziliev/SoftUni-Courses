using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Cards
{
    public interface ICard
    {
        public string Face { get; }
        public string Suit { get; }
    }
}
