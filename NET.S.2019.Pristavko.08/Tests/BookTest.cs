namespace NET.S._2019.Pristavko._08.Tests
{
    using System.Globalization;
    using NUnit.Framework;

    public class BookTest
    {
        #region test string format

        [Test]
        [TestCase("IATPYCP", ExpectedResult = "ISBN 13: 978-1-491-92706-9, Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell, O’Reilly Media, 2015, P. 4000, $55.00")]
        [TestCase("IATPYC", ExpectedResult = "ISBN 13: 978-1-491-92706-9, Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell, O’Reilly Media, 2015, P. 4000")]
        [TestCase("IATPY", ExpectedResult = "ISBN 13: 978-1-491-92706-9, Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell, O’Reilly Media, 2015")]
        [TestCase("ATPY", ExpectedResult = "Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell, O’Reilly Media, 2015")]
        [TestCase("IATP", ExpectedResult = "ISBN 13: 978-1-491-92706-9, Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell, O’Reilly Media")]
        [TestCase("IAT", ExpectedResult = "ISBN 13: 978-1-491-92706-9, Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell")]
        [TestCase("AT", ExpectedResult = "Joseph Albahari & Ben Albahari, C# 6.0 in a Nutshell")]
        public string BookFormat_Succed(string format)
        {
            Book bookToFormat = new Book("978-1-491-92706-9", "Joseph Albahari & Ben Albahari", "C# 6.0 in a Nutshell", "O’Reilly Media", 2015, 4000, 55);
            return bookToFormat.ToString(format, new CultureInfo("en-Us"));
        }

        #endregion
    }
}
