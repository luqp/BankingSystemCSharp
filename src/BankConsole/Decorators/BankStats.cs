using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BankingSystem.Bank;

namespace BankingSystem
{
    public class BankStats : Bank.Bank
    {
        private Bank.Bank bank;

        public BankStats(Bank.Bank bank)
        {
            this.bank = bank;
        }

        // public override int NewAccount(AccountOrigin origin = AccountOrigin.LOCAL) {
        //     Stopwatch stopwatch = new Stopwatch();
        //     stopwatch.Start();

        //     int account = bank.NewAccount(origin);

        //     stopwatch.Stop();

        //     using (StreamWriter stream = File.AppendText("stats.txt")) 
        //     {
        //         stream.WriteLine(DateTime.Now.ToString() + ": Creating an account in " + stopwatch.ElapsedMilliseconds);
        //     }

        //     return account;
        // }

        public override string ToString() {
            Console.WriteLine(DateTime.Now.ToString() + ": Seeing accounts");
            return bank.ToString();
        }
    }
}
