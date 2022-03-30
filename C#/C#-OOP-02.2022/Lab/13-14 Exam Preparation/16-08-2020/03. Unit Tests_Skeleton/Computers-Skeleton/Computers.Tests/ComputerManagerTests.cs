using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;
        [SetUp]
        public void Setup()
        {
            manager = new ComputerManager();
        }

        [Test]
        public void Test18()
        {
            Assert.IsNotNull(manager);
            Assert.AreEqual(0,manager.Computers.Count);
        }

        [Test]
        public void Test1()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);

            Assert.AreEqual("ASUS",computer.Manufacturer);
            Assert.AreEqual("P700",computer.Model);
            Assert.AreEqual(758.68,computer.Price);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Test3()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            Computer computer2 = null;

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(computer2));
        }

        [Test]
        public void Test4()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer2));
        }

        [Test]
        public void Test5()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.AreEqual(3, manager.Count);
        }

        [Test]
        public void Test6()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var currentComp = manager.GetComputer("ACER", "P900");

            Assert.AreEqual(currentComp, computer1);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("ACER", "P9010"), "There is no computer with this manufacturer and model.");
            Assert.Throws<ArgumentException>(() => manager.GetComputer("ACER1", "P900"), "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void Test7()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.AreEqual(3, manager.Count);

            Assert.AreEqual(computer2, manager.RemoveComputer("ACER", "P1900"));

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void Test8()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "P900"), "Can not be null!");
        }

        [Test]
        public void Test9()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("ACER", null), "Can not be null!");
        }

        [Test]
        public void Test10()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("HP", "1958.52"), "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void Test11()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var comps = manager.GetComputersByManufacturer("ACER");
            
            Assert.AreEqual(2, comps.Count);
        }

        [Test]
        public void Test13()
        {
            var computer = new Computer("ASUS", "P700", 758.68m);
            var computer1 = new Computer("ACER", "P900", 1799.99m);
            var computer2 = new Computer("ACER", "P1900", 1899.99m);

            manager.AddComputer(computer);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var comps = manager.GetComputersByManufacturer("HP");

            Assert.AreEqual(0, comps.Count);
        }

        [Test]
        public void Test15()
        {

            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("1","2"), "There is no computer with this manufacturer and model.");


        }

    }
}