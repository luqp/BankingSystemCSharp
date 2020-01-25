using System;
using System.Diagnostics;
using System.IO;
using BankingSystem.BankLogic;

namespace BankingSystem
{
    public class BankStats : BankLogic.Bank
    {
        private BankLogic.Bank bank;

        public BankStats(BankLogic.Bank bank)
        {
            this.bank = bank;
        }

        public override int AddNewAccount(AccountType type, AccountOrigin origin = AccountOrigin.LOCAL) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int account = bank.AddNewAccount(type, origin);

            stopwatch.Stop();

            using (StreamWriter stream = File.AppendText("stats.txt")) 
            {
                stream.WriteLine(DateTime.Now.ToString() + ": Creating an account in " + stopwatch.ElapsedMilliseconds);
            }

            return account;
        }

        public override string ToString() {
            Console.WriteLine(DateTime.Now.ToString() + ": Seeing accounts");
            return bank.ToString();
        }
    }
}
