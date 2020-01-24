using System;
using System.IO;
using System.Collections.Generic;
using BankingSystem.Bank;

namespace BankingSystem
{
    public class BankWithFileLogger : Bank.Bank
    {
        private Bank.Bank bank;

        public BankWithFileLogger(Bank.Bank bank)
        {
            this.bank = bank;
        }

        // public override int NewAccount(AccountOrigin origin = AccountOrigin.LOCAL) {
        //     using (StreamWriter stream = File.AppendText("file.txt")) 
        //     {
        //         stream.WriteLine(DateTime.Now.ToString() + ": Creating an account");
        //     }

        //     return bank.NewAccount(origin);
        // }

        public override string ToString() {
            using (StreamWriter stream = File.AppendText("file.txt")) 
            {
                stream.WriteLine(DateTime.Now.ToString() + ": Seeing accounts");
            }
       
            return bank.ToString();
        }
    }
}
