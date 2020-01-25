using System;
using System.IO;
using BankingSystem.BankLogic;

namespace BankingSystem
{
    public class BankWithFileLogger : BankLogic.Bank
    {
        private BankLogic.Bank bank;

        public BankWithFileLogger(BankLogic.Bank bank)
        {
            this.bank = bank;
        }

        public override int AddNewAccount(AccountType type, AccountOrigin origin = AccountOrigin.LOCAL) {
            using (StreamWriter stream = File.AppendText("file.txt")) 
            {
                stream.WriteLine(DateTime.Now.ToString() + ": Creating an account");
            }

            return bank.AddNewAccount(type, origin);
        }

        public override string ToString() {
            using (StreamWriter stream = File.AppendText("file.txt")) 
            {
                stream.WriteLine(DateTime.Now.ToString() + ": Seeing accounts");
            }
       
            return bank.ToString();
        }
    }
}
