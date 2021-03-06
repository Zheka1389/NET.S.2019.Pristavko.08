﻿namespace NET.S._2019.Pristavko._08
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    public class Bank : IEnumerable
    {
        private string path = @"C:\BankAccount.txt";
        private List<Bank> accounts;
        private string id;
        private decimal ballance;
        private decimal discount;
        private string fName;
        private string sName;
        private decimal bonusPoints;
        private string rate;
        
        public string Id
        {
            get => this.id;

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

                this.id = value;
            }
        }

        public decimal Ballance
        {
            get => this.ballance;

            set
            {
                this.ballance = value;
            }
        }

        public decimal Discount
        {
            get => this.discount;

            set
            {
                this.discount = value;
            }
        }

        public string FName
        {
            get => this.fName;

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

                this.fName = value;
            }
        }

        public string SName
        {
            get => this.sName;

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

                this.sName = value;
            }
        }

        public decimal BonusPoints
        {
            get => this.bonusPoints;

            set
            {
                this.bonusPoints = value;
            }
        }

        public string Rate
        {
            get => this.rate;

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

                this.rate = value;
            }
        }

        #region Constructors

        public Bank(string id, decimal ballance, string fName, string sName, decimal bonusPoints, string rate)
        {
            this.Id = id;
            this.Ballance = ballance;
            this.discount = 1;
            this.FName = fName;
            this.SName = sName;
            this.BonusPoints = bonusPoints;
            this.rate = rate;
            this.accounts = new List<Bank>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds the money to the accout
        /// </summary>
        /// <param name="amount">Amount of money to add</param>
        public void PutMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} can not be less than zero");
            }

            switch (rate)
            {
                case "Gold":
                    this.discount = 2;
                    break;
                case "Platinum":
                    this.discount = 3;
                    break;
                default:
                    this.discount = 1;
                    break;
            }
            this.Ballance += amount * this.discount;
            Save(this.path);
        }

        public void TakeMoney(decimal amount)
        {
            if (this.Ballance - amount < 0)
            {
                throw new ArgumentException($"{nameof(amount)} can not be less than ballance");
            }

            this.Ballance -= amount;
            Save(this.path);
        }

        #endregion

        public void Save(string path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Bank s in this.accounts)
                {
                    writer.Write(s.Id);
                    writer.Write(s.Ballance);
                    writer.Write(s.FName);
                    writer.Write(s.SName);
                    writer.Write(s.BonusPoints);
                    writer.Write(s.Rate);
                }
            }
        }

        public static List<Bank> Read(string path)
        {
            List<Bank> Accounts = new List<Bank>();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string id = reader.ReadString();
                    decimal ballance = reader.ReadDecimal();
                    string fName = reader.ReadString();
                    string sName = reader.ReadString();
                    decimal bonusPoints = reader.ReadDecimal();
                    string rate = reader.ReadString();
                    var temp = new Bank(id, ballance, fName, sName, bonusPoints, rate);
                    Accounts.Add(temp);
                }
            }

            return Accounts;
        }

        public override string ToString()
        {
            return $"[Id: {this.Id};\n HolderName: {this.SName}; " +
                $"\n Balance: {this.Ballance}; \n BonusPoints: {this.BonusPoints};]";
        }

        public IEnumerator GetEnumerator()
        {
            return this.accounts.GetEnumerator();
        }
    }
}
