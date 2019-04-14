using System;
using System.Collections.Generic;
using System.Globalization;

namespace NET.S._2019.Pristavko._08
{
    /// <summary>
    /// Book class.
    /// </summary>
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Private fields

        /// <summary>
        /// Private field isbn
        /// </summary>
        private string isbn;

        /// <summary>
        /// Private field Author.
        /// </summary>
        private string author;

        /// <summary>
        /// Private field Title.
        /// </summary>
        private string title;

        /// <summary>
        /// Private field publisher.
        /// </summary>
        private string publisher;

        /// <summary>
        /// Private field yearOfPublishing.
        /// </summary>
        private int yearOfPublishing;

        /// <summary>
        /// Private field count.
        /// </summary>
        private int count;

        /// <summary>
        /// Private field price.
        /// </summary>
        private decimal price;

        #endregion

        #region Propertias

        /// <summary>
        /// Property ISBN.
        /// </summary>
        public string ISBN
        {
            get => this.isbn;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Property Author.
        /// </summary>
        public string Author
        {
            get => this.author;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this.author = value;
            }
        }

        /// <summary>
        /// Property Title.
        /// </summary>
        public string Title
        {
            get => this.title;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Property Publisher.
        /// </summary>
        public string Publisher
        {
            get => this.publisher;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException($"{nameof(value)} must be not empty");
                }

                this.publisher = value;
            }
        }

        /// <summary>
        /// Property year of publishing.
        /// </summary>
        public int YearOfPublishing
        {
            get => this.yearOfPublishing;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                this.yearOfPublishing = value;
            }
        }

        /// <summary>
        /// Property Count.
        /// </summary>
        public int Count
        {
            get => this.count;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                this.count = value;
            }
        }

        /// <summary>
        /// Property Price.
        /// </summary>
        public decimal Price
        {
            get => this.price;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(value)} must be greater than 0");
                }

                this.price = value;
            }
        }

        #endregion

        #region Public methods
        
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified object instance.
        /// </summary>
        /// <param name="obj">
        /// A object instance to compare with this instance.
        /// </param>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// Returns a value indicating  wheter this instance is equal to a specified <see cref="Book"/> instance.
        /// </summary>
        /// <param name="other">
        /// A <see cref="Book"/> instance to compare with this <see cref="Book"/> instance.
        /// </param>
        public bool Equals(Book other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.InnerCompare(other);
        }

        /// <summary>
        /// Compares the current instance with another object of the <see cref="Book"/> and returns
        /// an integer that indicates whether the current instance precedes.
        /// </summary>
        /// <param name="other">
        /// A object of <see cref="Book"/> to compare with this instance.
        /// </param>
        /// <returns>
        /// If <paramref name="other"/> is same then return 0.
        /// If <paramref name="other"/> less than this instance then return 1.
        /// If <paramref name="other"/> greater than this instance then return -1.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return 1;
            }

            return this.Price.CompareTo(other.Price);
        }

        /// <summary>
        /// Converts <see cref="Book"/> states of this instance to its equvalent string representation.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            string bookAsString = $"ISBN: {this.ISBN}; \nAutor: {this.Author}; \nTitle: {this.Title}; \nPublisher: {this.Publisher};" +
                $"\nYearOfPublishing: {this.YearOfPublishing}; \nCount: {this.Count}; \nPrice: {this.Price}";
            return bookAsString;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "IATPYCP";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "IATPYCP":
                    return $"ISBN 13: {this.ISBN}, {this.Author}, {this.Title}, {this.Publisher}, {this.YearOfPublishing}, P. {this.Count}, {this.Price.ToString("C", formatProvider)}";
                case "IATPYC":
                    return $"ISBN 13: {this.ISBN}, {this.Author}, {this.Title}, {this.Publisher}, {this.YearOfPublishing}, P. {this.Count}";
                case "IATPY":
                    return $"ISBN 13: {this.ISBN}, {this.Author}, {this.Title}, {this.Publisher}, {this.YearOfPublishing}";
                case "IATP":
                    return $"ISBN 13: {this.ISBN}, {this.Author}, {this.Title}, {this.Publisher}";
                case "ATPY":
                    return $"{this.Author}, {this.Title}, {this.Publisher}, {this.YearOfPublishing}";
                case "IAT":
                    return $"ISBN 13: {this.ISBN}, {this.Author}, {this.Title}";
                case "AT":
                    return $"{this.Author}, {this.Title}";
            }

            throw new FormatException($"{format} is not supported");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class by parameters.
        /// </summary>
        /// <param name="isbn">The international standard book number.</param>
        /// <param name="author">The autor of book.</param>
        /// <param name="name">The name book.</param>
        /// <param name="publisher">The publisher book.</param>
        /// <param name="yearOfPublishing">Year of publication.</param>
        /// <param name="count">Count of pages.</param>
        /// <param name="price">The price.</param>
        /// <exception cref="ArgumentException">
        /// If any parameters does not match format.
        /// </exception>
        public Book(string isbn, string author, string name, string publisher, int yearOfPublishing, int count, decimal price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Title = name;
            this.Publisher = publisher;
            this.YearOfPublishing = yearOfPublishing;
            this.Count = count;
            this.Price = price;
        }

        #endregion

        #region Private methods

        private bool InnerCompare(Book other)
        {
            if (string.Compare(this.ISBN, other.ISBN, StringComparison.Ordinal) != 0)
            {
                return false;
            }

            if (string.Compare(this.Title, other.Title, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }

            if (string.Compare(this.Author, other.Author, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }

            if (string.Compare(this.Publisher, other.Publisher, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                return false;
            }

            if (this.YearOfPublishing != other.YearOfPublishing)
            {
                return false;
            }

            if (this.Count != other.Count)
            {
                return false;
            }

            if (this.Price != other.Price)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Return numeric representation this book instance.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            var hashCode = -2103712403;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ISBN);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = hashCode * -1521134295 + YearOfPublishing.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }

        #endregion
    }
}
