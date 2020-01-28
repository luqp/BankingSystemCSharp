using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class Withdraw : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.Write("Enter withdraw amount: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int amount);

            bankService.Withdraw(currentAccount, amount);
            return currentAccount;
        }

        public override string ToString()
        {
            return "withdraw";
        }
    }
}
