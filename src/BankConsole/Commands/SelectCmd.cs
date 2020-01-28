using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class SelectCmd : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.Write("Enter account#: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out currentAccount);

            int balance = bankService.GetBalance(currentAccount);
            Console.WriteLine($"The balance of account {currentAccount} is {balance}");

            return currentAccount;
        }

        public override string ToString()
        {
            return "select";
        }
    }
}
