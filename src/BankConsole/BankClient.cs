using System;
using BankingSystem.BankLogic;

namespace BankingSystem
{
    public class BankClient
    {
        private bool done;
        private int currentAccount;
        private BankService bankService;

        public BankClient()
        {
            this.done = false;
            this.currentAccount = 0;        
        }

        public void run(BankService bankService)
        {
            
            this.bankService = bankService;
            while(!done)
            {
                Console.Write("Enter command (0=quit, 1=new, 2=select, 3=deposit, 4=loan, 5=show, 6=interest): ");
                string input = Console.ReadLine();
                
                if(!Int32.TryParse(input, out int commandNumber))
                {
                    commandNumber = Int32.MaxValue;
                }

                try
                {
                    ProcessCommand(commandNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(int commandNumber)
        {
            switch (commandNumber)
            {
                case 0:
                    quit();
                    break;
                case 1:
                    newAccount();
                    break;
                case 2:
                    select();
                    break;
                case 3:
                    deposit();
                    break;
                case 4:
                    authorizeLoan();
                    break;
                case 5:
                    showAll();
                    break;
                case 6:
                    addInterest();
                    break;
                default:
                    Console.WriteLine("Illegal command");
                    break;
            }
        }

        private void quit()
        {
            done = true;
            Console.WriteLine("Byeee...");
        }

        private void newAccount()
        {
            Console.Write("Specify the 'origin' of the account (Local, Rural, Foreign): ");
            string accountOrigin = Console.ReadLine();
            Console.Write("Specify the 'type' of the account\n\t1 (Checking account)\n\t2 (Saving account)\n:");
            string accountType = Console.ReadLine().Replace(" ", "").Replace("\t", "");
            currentAccount = bankService.NewAccount(accountType, accountOrigin);
            Console.WriteLine("Your new account number is: " + currentAccount);
        }

        private void select()
        {
            Console.Write("Enter account#: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out currentAccount);
            
            int balance = bankService.GetBalance(currentAccount);
            Console.WriteLine($"The balance of account {currentAccount} is {balance}");
        }

        private void deposit()
        {
            Console.Write("Enter deposit amount: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int amount);
            
            bankService.Deposit(currentAccount, amount);
        }

        private void authorizeLoan()
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
        }

        private void showAll()
        {
            Console.WriteLine(bankService.GetBankInformation());
        }

        private void addInterest()
        {
            bankService.PayInterest();
            Console.WriteLine("Interes were payed.");
        }
    }

}
