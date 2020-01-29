using BankingSystem.BankLogic;
using System;

namespace BankConsole.Commands
{
    class AuthorizeLoan : ICommand
    {
        public int Execute(BankService bankService, int currentAccount)
        {
            Console.Write("Enter loan amount: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int loanAmount);

            if (bankService.AuthorizeLoan(currentAccount, loanAmount))
            {
                Console.WriteLine("The loan was approved");
            }
            else
            {
                Console.WriteLine("The loan was denied");
            }

            return currentAccount;
        }

        public override string ToString()
        {
            return "loan";
        }
    }
}
