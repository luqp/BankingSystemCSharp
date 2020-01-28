using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class ShowCmd : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.WriteLine(bankService.GetBankInformation());
            return currentAccount;
        }

        public override string ToString()
        {
            return "show";
        }
    }
}
