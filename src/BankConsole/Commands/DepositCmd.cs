using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class DepositCmd : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.Write("Enter deposit amount: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int amount);

            bankService.Deposit(currentAccount, amount);
            return currentAccount;
        }

        public override string ToString()
        {
            return "deposit";
        }
    }
}
