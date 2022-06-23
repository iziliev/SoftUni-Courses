namespace Book.Tests
{
    using System;
    using NUnit.Framework;
    
    public class Tests
    {
        [Test]
        public void CreateNewBookCorrectData()
        {
            Book book = new Book("Ivo", "Niki");

            Assert.AreEqual(0,book.FootnoteCount);
            Assert.AreEqual("Ivo",book.BookName);
            Assert.AreEqual("Niki", book.Author);
        }

        [Test]
        public void CreateNewBookInvalidNameNull()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "Niki"));
        }

        [Test]
        public void CreateNewBookInvalidNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Niki"));
        }

        [Test]
        public void CreateNewBookInvalidAuthorNull()
        {
            Assert.Throws<ArgumentException>(() => new Book("Ivo", null));
        }

        [Test]
        public void CreateNewBookInvalidAuthorEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("Ivo", ""));
        }

        [Test]
        public void AddFootNote()
        {
            Book book = new Book("Ivo", "Niki");
            book.AddFootnote(15, "Text");
            Assert.AreEqual(1,book.FootnoteCount);
        }

        [Test]
        public void AddExistFootNote()
        {
            Book book = new Book("Ivo", "Niki");
            book.AddFootnote(15, "Text");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(15, "Text"));
        }

        [Test]
        public void FindFootnoteNotExist()
        {
            Book book = new Book("Ivo", "Niki");
            book.AddFootnote(15, "Text");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(18));
        }

        [Test]
        public void FindFootnoteExist()
        {
            Book book = new Book("Ivo", "Niki");
            book.AddFootnote(15, "Text");
            book.AddFootnote(18, "Text1");

            Assert.AreEqual($"Footnote #18: Text1", book.FindFootnote(18));
        }

        [Test]
        public void AlterFootnoteChangeTextExist()
        {
            Book book = new Book("Ivo", "Niki");
            book.AddFootnote(15, "Text");
            book.AddFootnote(18, "Text1");

            book.AlterFootnote(18, "Text8");
            Assert.AreEqual($"Footnote #18: Text8", book.FindFootnote(18));
        }

        [Test]
        public void AlterFootnoteChangeTextNotExist()
        {
            Book book = new Book("Ivo", "Niki");
            book.AddFootnote(15, "Text");
            book.AddFootnote(18, "Text1");


            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(25, "Text8"));
        }
    }
}