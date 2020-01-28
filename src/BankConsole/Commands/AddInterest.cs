using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class AddInterest : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            bankService.PayInterest();
            Console.WriteLine("Interes were payed.");
            return currentAccount;
        }

        public override string ToString()
        {
            return "interest";
        }
    }
}
