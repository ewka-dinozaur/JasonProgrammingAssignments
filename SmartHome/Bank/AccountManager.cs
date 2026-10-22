using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    internal class AccountManager<T> where T : BankAccount // constraint that Account Manager working on type T where T is BankAccount object 
    {

        private List<T> _accounts = new List<T>(); // private list object with elements of type T 

        public void Add(T account) // add elementy of type T with name account
        {
            _accounts.Add(account);
        }
        public int Count => _accounts.Count; // policz wszystkie rachunki z listy _accounts

        public T FindHighestInterest()
        {
            T best = _accounts[0];
            foreach (var account in _accounts)
                if (account.CalculateInterest() > best.CalculateInterest())
                    best = account;
            return best;
        }

    }
}

