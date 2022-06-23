namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void HasInicializeConstructor()
        {
            var aquarium = new Aquarium("See", 20);

            Assert.AreEqual(20, aquarium.Capacity);
            Assert.AreEqual("See", aquarium.Name);
        }

        [Test]
        public void IsNameIsAreEmptyString()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 20));
        }

        [Test]
        public void IsNameIsNullString()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 20));
        }

        [Test]
        public void IsCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("See", -20));
        }

        [Test]
        public void IsCountCorrect()
        {
            var aquarium = new Aquarium("See", 20);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add( new Fish("Ivo1"));
            aquarium.Add(new Fish("Ivo2"));

            Assert.AreEqual(3, aquarium.Count);
        }

        [Test]
        public void IsCapacityExeption()
        {
            var aquarium = new Aquarium("See", 2);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add(new Fish("Ivo1"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Ivo2")));
        }

        [Test]
        public void RemoveFishExeption()
        {
            var aquarium = new Aquarium("See", 2);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add(new Fish("Ivo1"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ivo2"));
        }

        [Test]
        public void RemoveFishCorrectly()
        {
            var aquarium = new Aquarium("See", 2);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add(new Fish("Ivo1"));
            
            aquarium.RemoveFish("Ivo");

            Assert.AreEqual(1, aquarium.Count);
        }

        public void SellFishExeption()
        {
            var aquarium = new Aquarium("See", 2);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add(new Fish("Ivo1"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Ivo2"));
        }

        [Test]
        public void SellFishCorrectly()
        {
            var aquarium = new Aquarium("See", 2);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add(new Fish("Ivo1"));

            aquarium.SellFish("Ivo");

            Assert.IsFalse(aquarium.SellFish("Ivo").Available);
        }

        [Test]
        public void ReportCheck()
        {
            var aquarium = new Aquarium("See", 5);
            aquarium.Add(new Fish("Ivo"));
            aquarium.Add(new Fish("Ivo1"));
            aquarium.Add(new Fish("Ivo2"));
            aquarium.Add(new Fish("Ivo3"));
            aquarium.Add(new Fish("Ivo4"));

            aquarium.Report();

            Assert.AreEqual($"Fish available at See: Ivo, Ivo1, Ivo2, Ivo3, Ivo4", aquarium.Report());
        }

        [Test]
        public void IsFishIsCorrect()
        {
            var fish = new Fish("nnn");

            Assert.AreEqual("nnn",fish.Name);
            Assert.IsTrue(fish.Available);
        }
    }
}
