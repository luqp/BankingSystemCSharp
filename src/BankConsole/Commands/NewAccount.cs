using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class NewAccount : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.Write("Specify the 'origin' of the account (Local, Rural, Foreign): ");
            string accountOrigin = Console.ReadLine();

            Console.Write("Specify the 'type' of the account\n\t1 (Saving account)\n\t2 (Regular checking account)\n\t3 (Interest checking account)\n:");
            string accountType = Console.ReadLine().Replace(" ", "").Replace("\t", "");

            currentAccount = bankService.NewAccount(accountType, accountOrigin);
            Console.WriteLine("Your new account number is: " + currentAccount);

            return currentAccount;
        }

        public override string ToString()
        {
            return "new";
        }
    }
}
