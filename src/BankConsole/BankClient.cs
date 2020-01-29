using System;
using BankingSystem.BankLogic;
using BankConsole.Commands;
using System.Text;

namespace BankingSystem
{
    public class BankClient
    {
        private bool done;
        private int currentAccount;
        private BankService bankService;
        private CommandFactory cmdFactory = new CommandFactory();

        public BankClient()
        {
            done = false;
            currentAccount = 0;

        }

        public void run(BankService bankService)
        {
            
            this.bankService = bankService;
            while(!done)
            {
                Console.Write(GenerateMessage());
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

        private string GenerateMessage()
        {
            string[] cmds = cmdFactory.cmdNames();
            StringBuilder message = new StringBuilder("Enter command (");
            int lastItem = cmds.Length - 1;

            for (int i = 0; i < lastItem; i++)
            {
                message.Append($"{i}={cmds[i]} ");
            }
            message.Append($"{lastItem}={cmds[lastItem]}): ");
            return message.ToString();
        }

        private void ProcessCommand(int number)
        {
            currentAccount = cmdFactory.GetCommand(number).Execute(bankService, currentAccount);

            if (currentAccount < 0)
            {
                done = true;
            }
        }
    }
}
