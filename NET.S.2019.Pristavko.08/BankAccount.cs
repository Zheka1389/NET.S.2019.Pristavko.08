using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.S._2019.Pristavko._08
{
    public class BankAccount : IEnumerable
    {

        public List<Bank> Accounts;
        public BankAccount()
        {
            Accounts = new List<Bank>();
        }

        public IEnumerator GetEnumerator()
        {
            return Accounts.GetEnumerator();
        }

        public void AddBank(Bank account)
        {
            if (Accounts.Contains(account))
                throw new ArgumentException($"The book is alredy in the {nameof(account)} list");

            Accounts.Add(account);
        }

        public void RemoveBank(Bank account)
        {
            if (Accounts.Contains(account))
                throw new ArgumentException($"The book is alredy in the {nameof(account)} list");

            Accounts.Remove(account);
        }

    } 
}
