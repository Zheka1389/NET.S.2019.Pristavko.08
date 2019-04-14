namespace NET.S._2019.Pristavko._08
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Implementation a service to work with list of <see cref="Book"/>.
    /// </summary>
    public class BookListService : IEnumerable
    {     

        public BookListService()
        {
            this.books = new List<Book>();
        }

        public int NumberOfBooks => this.books.Count;

        #region Public Methods

        public void AddBook(Book book)
        {
            if (this.books.Contains(book))
            {
                throw new ArgumentException($"The book is alredy in the {nameof(books)} list");
            }

            this.books.Add(book);
        }

        /// <summary>
        /// Removes the given object from the list
        /// </summary>
        /// <exception>
        /// Throws when the list does not contain the given object
        /// </exception>
        /// <param name="book">A book object</param>
        public void RemoveBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"The {nameof(book)} is null");
            }

            if (this.books.Contains(book))
            {
                this.books.Remove(book);
            }
            else
            {
                throw new ArgumentException("The list does not contain the given object");
            }
        }

        public Book FindBookByTag(dynamic title)
        {
            if (title == null)
            {
                throw new ArgumentNullException();
            }

            if (this.books != null)
            {
                foreach (Book bookInList in this.books)
                {                  
                    if (bookInList.ToString().Contains(title.ToString()))
                    {
                        return bookInList;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public void SortBooksByTag()
        {
            var sortedBooks = from b in this.books
                              orderby b.YearOfPublishing
                              select b;
            this.books = new List<Book>(sortedBooks);
        }

        #endregion

        public void Save(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book s in this.books)
                {
                    writer.Write(s.ISBN);
                    writer.Write(s.Author);
                    writer.Write(s.Title);
                    writer.Write(s.Publisher);
                    writer.Write(s.YearOfPublishing);
                    writer.Write(s.Count);
                    writer.Write(s.Price);
                }
            }
        }

        public static BookListService Read(string path)
        {
            BookListService t = new BookListService();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int yearOfPublishing = reader.ReadInt32();
                    int count = reader.ReadInt32();
                    decimal price = reader.ReadDecimal();
                    var temp = new Book(isbn, author, title, publisher, yearOfPublishing, count, price);
                    t.AddBook(temp);
                }
            }

            return t;
        }

        public IEnumerator GetEnumerator()
        {
            return this.books.GetEnumerator();
        }

        #region Private Fields 

        private List<Book> books;

        #endregion
    }
}
