using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Cards
{
    public class Card : ICard
    {
        private readonly string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly Dictionary<string, string> validSuits = new Dictionary<string, string>
        {
            {"S",char.ToString('\u2660')},
            {"H",char.ToString('\u2665')},
            {"D",char.ToString('\u2666')},
            {"C",char.ToString('\u2663')}
        };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => face;
            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }

        public string Suit
        {
            get => suit;
            private set
            {
                if (!char.TryParse(value, out char result) || !validSuits.ContainsKey(result.ToString()))
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = validSuits[value];
            }
        }
        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
