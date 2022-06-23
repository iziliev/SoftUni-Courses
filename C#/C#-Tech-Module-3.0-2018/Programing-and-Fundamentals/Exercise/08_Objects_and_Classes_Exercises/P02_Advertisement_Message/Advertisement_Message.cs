using System;

namespace P02_Advertisement_Message
{
    class Advertisement_Message
    {
        static void Main()
        {
            string[] phrases = new string[]
            {
                "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };

            string[] events = new string[]
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            string[] autors = new string[]
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            string[] cities = new string[]
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random randomIndex = new Random();

            for (int i = 0; i < n; i++)
            {
                int randomPhrases = randomIndex.Next(0, phrases.Length);
                int randomEvents = randomIndex.Next(0, events.Length);
                int randomAutors = randomIndex.Next(0, autors.Length);
                int randomCity = randomIndex.Next(0, cities.Length);

                Console.WriteLine($"{phrases[randomPhrases]} {events[randomEvents]} {autors[randomAutors]} - {cities[randomCity]}");
            }
        }
    }
}
