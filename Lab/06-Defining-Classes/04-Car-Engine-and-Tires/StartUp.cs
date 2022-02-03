using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var make = Console.ReadLine();
            var model = Console.ReadLine();
            var year = int.Parse(Console.ReadLine());
            var fuelQuantity = double.Parse(Console.ReadLine());
            var fuelConsumption = double.Parse(Console.ReadLine());

            var tires = new Tire[4];
            tires[0] = new Tire(1, 2.5);
            tires[1] = new Tire(1, 2.1);
            tires[2] = new Tire(2, 0.5);
            tires[3] = new Tire(2, 2.3);

            var engine = new Engine(560, 6300);

            var firstCar = new Car();
            var secondCar = new Car(make, model, year);
            var thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            var fourthCar = new Car(make,model,year, fuelQuantity, fuelConsumption,engine,tires);

            firstCar.Drive(150);
            secondCar.Drive(250);
            thirdCar.Drive(450);
            fourthCar.Drive(580);

            Console.WriteLine(new String('-', 25));
            Console.WriteLine(firstCar.WhoIAm());
            Console.WriteLine(new String('-', 25));
            Console.WriteLine(secondCar.WhoIAm());
            Console.WriteLine(new String('-', 25));
            Console.WriteLine(thirdCar.WhoIAm());
            Console.WriteLine(new String('-', 25));
            Console.WriteLine(fourthCar.WhoIAm());

        }
    }
}
