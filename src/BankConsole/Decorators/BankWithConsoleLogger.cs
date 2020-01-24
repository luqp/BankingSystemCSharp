using System;
using System.Collections.Generic;
using BankingSystem.Bank;

namespace BankingSystem
{
    public class BankWithConsoleLogger : Bank.Bank
    {
        private Bank.Bank bank;

        public BankWithConsoleLogger(Bank.Bank bank)
        {
            this.bank = bank;
        }

        // public override int NewAccount(AccountOrigin origin = AccountOrigin.LOCAL) {
        //     Console.WriteLine(DateTime.Now.ToString() + ": Creating an account");
        //     return bank.NewAccount(origin);
        // }

        public override string ToString() {
            Console.WriteLine(DateTime.Now.ToString() + ": Seeing accounts");
            return bank.ToString();
        }
    }
}
