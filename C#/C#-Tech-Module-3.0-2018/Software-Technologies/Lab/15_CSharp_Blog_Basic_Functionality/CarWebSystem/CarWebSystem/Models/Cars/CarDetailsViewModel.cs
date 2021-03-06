using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebSystem.Models.Cars
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
     
        public int Year { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
