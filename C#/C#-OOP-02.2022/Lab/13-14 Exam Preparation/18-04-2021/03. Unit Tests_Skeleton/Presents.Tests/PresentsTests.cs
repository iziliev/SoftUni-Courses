namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void SetConstructorPresent()
        {
            var present = new Present("Ivo",15.2);

            Assert.AreEqual("Ivo",present.Name);
            Assert.AreEqual(15.2,present.Magic);
        }

        [Test]
        public void CreateBag()
        {
            var present = new Present("Ivo", 15.2);
            var bag = new Bag();
            Assert.AreEqual(0, bag.GetPresents().Count);
            
        }
        [Test]
        public void CreateBagAddPresent()
        {
            var present = new Present("Ivo", 15.2);
            var bag = new Bag();
            bag.Create(present);
            var present1 = new Present("Ivo1", 18.2);


            Assert.AreEqual(1, bag.GetPresents().Count);
            Assert.AreEqual($"Successfully added present Ivo1.", bag.Create(present1));

        }

        [Test]
        public void CreateBagAddPresentNull()
        {
            Present present = null;
            var bag = new Bag();
            

            Assert.Throws<ArgumentNullException>(() => bag.Create(null));

        }

        [Test]
        public void CreateBagAddPresentExist()
        {
            var present = new Present("Ivo", 15.2);
            var bag = new Bag();
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateBagRemovePresent()
        {
            var present = new Present("Ivo", 15.2);
            var present1 = new Present("Ivo", 15.2);
            var present2 = new Present("Ivo", 15.2);
            var bag = new Bag();
            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);
            bag.Remove(present1);

            Assert.AreEqual(2, bag.GetPresents().Count);
            Assert.IsTrue(bag.Remove(present2));
            Assert.AreEqual(1, bag.GetPresents().Count);
            Assert.IsFalse(bag.Remove(present1));
        }

        [Test]
        public void CreateBagRemovePresentSmall()
        {
            var present = new Present("Ivo", 3);
            var present1 = new Present("Ivo1", 12);
            var present2 = new Present("Ivo2", 15);
            var bag = new Bag();
            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());

        }

        [Test]
        public void CreateBagRemovePresentGet()
        {
            var present = new Present("Ivo", 3);
            var present1 = new Present("Ivo1", 12);
            var present2 = new Present("Ivo2", 15);
            var bag = new Bag();
            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(present1, bag.GetPresent("Ivo1"));
        }
    }
}
