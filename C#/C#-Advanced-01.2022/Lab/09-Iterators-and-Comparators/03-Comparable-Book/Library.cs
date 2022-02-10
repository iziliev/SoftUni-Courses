using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        private SortedSet<Book> books;
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books.ToList());
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;
            public LibraryIterator(List<Book> books)
            {
                this.books=books;
                this.Reset();
            }
            public Book Current => this.books[index];
            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }
            public bool MoveNext()
            {
                index++;
                return index < books.Count;
            }
            public void Reset()
            {
                this.index=-1;
            }
        }
    }
}
