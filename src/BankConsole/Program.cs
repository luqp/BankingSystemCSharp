using System;
using System.Collections.Generic;
using BankingSystem.BusinessLogic;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            Bank bank = new Bank(accounts);
            BankService bankService = new BankService(bank);
            BankClient bankSystem = new BankClient();
            bankSystem.run(bankService);
        }
    }
}
