using System;
using System.Collections.Generic;
using BankingSystem.Bank;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareBankAccounts.Run();
            
            BankService bankService = new BankService(new Bank.Bank());
            BankClient bankSystem = new BankClient();
            bankSystem.run(bankService);

        }
    }
}
