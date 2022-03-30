using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CarTest1()
        {
            var unitCar = new UnitCar("Honda", 90, 1493);

            Assert.AreEqual("Honda",unitCar.Model);
            Assert.AreEqual(90, unitCar.HorsePower);
            Assert.AreEqual(1493, unitCar.CubicCentimeters);
        }

        [Test]
        public void DriverTest1()
        {
            var car = new UnitCar("Honda", 90, 1493);
            var driver = new UnitDriver("Ivaylo",car);

            Assert.Throws<ArgumentNullException>(()=>new UnitDriver(null,car));

            Assert.AreEqual("Honda",driver.Car.Model);
            Assert.AreEqual("Ivaylo", driver.Name);
        }

        [Test]
        public void RaceTest1()
        {
            var race = new RaceEntry();

            Assert.AreEqual(0,race.Counter);
        }

        [Test]
        public void RaceTest2()
        {
            var car = new UnitCar("Honda", 90, 1493);
            var driver = new UnitDriver("Ivaylo", car);

            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null), "Driver cannot be null.");

            var message = race.AddDriver(driver);

            Assert.AreEqual("Driver Ivaylo added in race.",message);

            Assert.AreEqual(1, race.Counter);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver), "Driver Ivaylo is already added.");
        }

        [Test]
        public void RaceTest3()
        {
            var car = new UnitCar("Honda", 90, 1493);
            var car1 = new UnitCar("Pejo", 190, 5893);
            var car2 = new UnitCar("Audi", 890, 10493);

            var driver = new UnitDriver("Ivaylo", car);
            var driver1 = new UnitDriver("Ivaylo1", car1);
            var driver2 = new UnitDriver("Ivaylo2", car2);

            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");

            race.AddDriver(driver);
            
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");

            race.AddDriver(driver1);
            race.AddDriver(driver2);

            Assert.AreEqual(390.0d, race.CalculateAverageHorsePower());
        }
        
    }
}