using System;
using BankingSystem.BankLogic;

namespace BankingSystem
{
    public class BankWithConsoleLogger : BankLogic.Bank
    {
        private BankLogic.Bank bank;

        public BankWithConsoleLogger(BankLogic.Bank bank)
        {
            this.bank = bank;
        }

        public override int AddNewAccount(AccountType type, AccountOrigin origin = AccountOrigin.LOCAL) {
            Console.WriteLine(DateTime.Now.ToString() + ": Creating an account");
            return bank.AddNewAccount(type, origin);
        }

        public override string ToString() {
            Console.WriteLine(DateTime.Now.ToString() + ": Seeing accounts");
            return bank.ToString();
        }
    }
}
