using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class QuitCmd : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.WriteLine("GoodBye.");
            return -1;
        }

        public override string ToString()
        {
            return "quit";
        }
    }
}
