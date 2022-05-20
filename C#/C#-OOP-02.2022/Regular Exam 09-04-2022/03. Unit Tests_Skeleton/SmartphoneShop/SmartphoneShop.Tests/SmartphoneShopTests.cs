using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test1()
        {
            var phone = new Smartphone("Nokia", 1500);

            Assert.AreEqual("Nokia", phone.ModelName);
            Assert.AreEqual(1500,phone.MaximumBatteryCharge);
            Assert.AreEqual(1500,phone.CurrentBateryCharge);
        }

        [Test]
        public void Test2()
        {
            var shop = new Shop(2);

            Assert.AreEqual(2,shop.Capacity);
            Assert.AreEqual(0,shop.Count);
        }

        [Test]
        public void Test3()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-5), "Invalid capacity.");
        }

        [Test]
        public void Test4()
        {
            var phone = new Smartphone("Nokia", 1500);
            var shop = new Shop(5);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(phone), "The phone model Nokia already exist.");
            Assert.AreEqual(1, shop.Count);

            var phone1 = new Smartphone("Nokia1", 1000);
            var phone2 = new Smartphone("Nokia2", 1200);
            var phone3 = new Smartphone("Nokia3", 1300);
            var phone4 = new Smartphone("Nokia4", 1400);

            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);

            Assert.AreEqual(5, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Nokia6", 1400)), "The shop is full.");
        }

        [Test]
        public void Test5()
        {
            var phone = new Smartphone("Nokia", 1500);
            var shop = new Shop(5);

            var phone1 = new Smartphone("Nokia1", 1000);
            var phone2 = new Smartphone("Nokia2", 1200);
            var phone3 = new Smartphone("Nokia3", 1300);
            var phone4 = new Smartphone("Nokia4", 1400);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);
            Assert.AreEqual(5, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Iphone"), "The phone model Iphone doesn't exist.");

            shop.Remove("Nokia3");

            Assert.AreEqual(4, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Nokia3"), "The phone model Nokia3 doesn't exist.");
        }

        [Test]
        public void Test6()
        {
            var phone = new Smartphone("Nokia", 1500);
            var shop = new Shop(5);

            var phone1 = new Smartphone("Nokia1", 1000);
            var phone2 = new Smartphone("Nokia2", 1200);
            var phone3 = new Smartphone("Nokia3", 1300);
            var phone4 = new Smartphone("Nokia4", 1400);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Iphone",500), "The phone model Iphone doesn't exist.");


            shop.TestPhone("Nokia3", 500);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia3",900), "The phone model Nokia3 is low on batery.");

            Assert.AreEqual(800, phone3.CurrentBateryCharge);
        }

        [Test]
        public void Test7()
        {
            var phone = new Smartphone("Nokia", 1500);
            var shop = new Shop(5);

            var phone1 = new Smartphone("Nokia1", 1000);
            var phone2 = new Smartphone("Nokia2", 1200);
            var phone3 = new Smartphone("Nokia3", 1300);
            var phone4 = new Smartphone("Nokia4", 1400);

            shop.Add(phone);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Add(phone4);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Iphone", 500), "The phone model Iphone doesn't exist.");


            shop.TestPhone("Nokia3", 500);

            Assert.AreEqual(800, phone3.CurrentBateryCharge);

            shop.ChargePhone("Nokia3");

            Assert.AreEqual(1300, phone3.CurrentBateryCharge);
        }

    }
}