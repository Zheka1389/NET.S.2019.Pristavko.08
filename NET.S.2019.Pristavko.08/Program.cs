using System;

namespace NET.S._2019.Pristavko._08
{
    class Program
    {
        static void Main(string[] args)
        {

            BankAccount acc = new BankAccount();
            Bank account = new Bank("0", 100, "Albahari", "Richter", 0, "Gold");
            acc.AddBank(account);
            foreach (var item in acc)
            {
                Console.WriteLine(item);
            }
            acc.Accounts[0].PutMoney(15);
            Console.WriteLine(account.Ballance);
            acc.Accounts.Add(new Bank("1", 150, "Bart De ", "Smet", 15, "Platinum"));
            acc.Accounts[1].PutMoney(20);
            foreach (Bank item in acc)
            {
                Console.WriteLine(item.Id + " = " + item.Ballance);
            }

            string path = @"C:\Test.txt";
            var book = new Book("978-1-491-92706-9", "Joseph Albahari & Ben Albahari", "C# 6.0 in a Nutshell", "O’Reilly Media", 2015, 4000, 55);
            var bookSecond = new Book("958-3-421-92506-9", "Jeffrey Richter", "CLR via C#", "Orelly", 2014, 2300, 50);
            var bookOther = new Book("928-1-441-92406-9", "Bart De Smet", "C# 5.0 Unleashed", "Orelly", 2013, 2900, 30);

            BookListService bk = BookListService.Read(path);

            foreach (Book item in bk)
            {
                Console.WriteLine(item.YearOfPublishing);
            }
            bk.SortBooksByTag();
            foreach (Book item in bk)
            {
                Console.WriteLine(item.YearOfPublishing);
            }
            Console.WriteLine(bk.FindBookByTag(950));
            //bk.RemoveBook(book);
            //bk.AddBook(book);
            //bk.AddBook(bookSecond);
            //bk.AddBook(bookOther);
            bk.Save(path);
            Console.ReadLine();
        }
    }
}
