using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
        }

        [Test]
        public void Test()
        {
            Item item = new Item("Ivo", "125");

            Assert.AreEqual("Ivo",item.Owner);
            Assert.AreEqual("125",item.ItemId);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }

        [Test]
        public void Test2()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A28", item));
        }

        [Test]
        public void Test3()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");

            bankVault.AddItem("A1", item);
            
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item1));
        }

        [Test]
        public void Test4()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");

            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);

            bool cellExists = bankVault.VaultCells.Values.Any(x => x?.ItemId == "1251");

            Assert.IsTrue(cellExists);
        }

        [Test]
        public void Test5()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");

            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);

            Item item25 = new Item("Ivo25", "1251");

            Assert.Throws<InvalidOperationException>(()=>bankVault.AddItem("A4",item25));
        }

        [Test]
        public void Test6()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");

            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);

            Item item25 = new Item("Ivo25", "12558");

            Assert.AreEqual($"Item:12558 saved successfully!", bankVault.AddItem("A4", item25));
        }

        [Test]
        public void Test7()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");
            Item item25 = new Item("Ivo25", "12558");
            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);
            bankVault.AddItem("A4", item25);

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A24", item25));
        }

        [Test]
        public void Test8()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");
            Item item25 = new Item("Ivo25", "12558");
            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);
            bankVault.AddItem("A4", item25);

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A4", item1));
        }

        [Test]
        public void Test9()
        {
            Item item = new Item("Ivo", "125");
            Item item1 = new Item("Ivo1", "1251");
            Item item25 = new Item("Ivo25", "12558");
            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);
            bankVault.AddItem("A4", item25);

            Assert.AreEqual("Remove item:1251 successfully!",bankVault.RemoveItem("A2", item1));

            Assert.AreEqual(null, bankVault.VaultCells["A2"]);
        }
    }
}
