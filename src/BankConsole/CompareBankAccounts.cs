using System;
using System.Collections.Generic;
using BankingSystem.Bank;

namespace BankingSystem
{
    public class CompareBankAccounts
    {
        public static void Run()
        {
            List<IBankAccount> accounts = InitAccounts();
            IBankAccount maxAccount1 = FindMax(accounts);
            Console.WriteLine($"Account with largest balance is {maxAccount1.Balance}");
        }

        private static List<IBankAccount> InitAccounts()
        {
            List<IBankAccount> accounts = new List<IBankAccount>();
            accounts.Add(new SavingsAccount(0, default(AccountOrigin)));
            accounts[0].Deposit(400);
            accounts.Add(new SavingsAccount(1, default(AccountOrigin)));
            accounts[1].Deposit(200);
            accounts.Add(new SavingsAccount(2, default(AccountOrigin)));
            accounts[2].Deposit(500);
            return accounts;
        }

        private static IBankAccount FindMax(List<IBankAccount> accounts)
        {
            IBankAccount max = accounts[0];
            foreach (IBankAccount account in accounts)
            {
                if (account.CompareTo(max) > 0)
                    max = account;
            }
            return max;
        }
    }
}