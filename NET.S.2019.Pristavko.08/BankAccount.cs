namespace NET.S._2019.Pristavko._08
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BankAccount : IEnumerable
    {
        public BankAccount()
        {
            this.accounts = new List<Bank>();
        }

        public IEnumerator GetEnumerator()
        {
            return this.accounts.GetEnumerator();
        }

        public void AddBank(Bank account)
        {
            if (this.accounts.Contains(account))
            {
                throw new ArgumentException($"The book is alredy in the {nameof(account)} list");
            }

            this.accounts.Add(account);
        }

        public void RemoveBank(Bank account)
        {
            if (this.accounts.Contains(account))
            {
                throw new ArgumentException($"The book is alredy in the {nameof(account)} list");
            }

            this.accounts.Remove(account);
        }

        private List<Bank> accounts;
    } 
}
