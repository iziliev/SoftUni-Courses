using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P04_Weather
{
    class Forecast
    {
        public double Temperature { get; set; }
        public string WeatherType { get; set; }

        public Forecast(double temp, string weatherType)
        {
            Temperature = temp;
            WeatherType = weatherType;
        }
    }

    class Weather
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Forecast> forecatByTown = new Dictionary<string, Forecast>();

            while (input != "end")
            {
                string pattern = @"([A-Z]{2})([\d\.]*[\d+])([A-Za-z]+)(\|)";

                Regex regex = new Regex(pattern);


                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);

                    string town = match.Groups[1].Value.ToString();
                    double temp = double.Parse(match.Groups[2].Value.ToString());
                    string weatherType = match.Groups[3].Value.ToString();

                    Forecast weather = new Forecast(temp, weatherType);

                    forecatByTown[town] = weather;
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }

            foreach (var item in forecatByTown.OrderBy(e=>e.Value.Temperature))
            {
                Console.WriteLine($"{item.Key} => {item.Value.Temperature:F2} => {item.Value.WeatherType}");
            }
            
        }
    }
}
