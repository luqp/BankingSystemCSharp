using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsole.Commands
{
    class CommandFactory
    {
        private ICommand[] commands = {
            new QuitCmd(),
            new NewAccount(),
            new SelectCmd(),
            new DepositCmd(),
            new Withdraw(),
            new AuthorizeLoan(),
            new ShowCmd(),
            new AddInterest()
        };

        public ICommand GetCommand(int commandNumber)
        {
            return commands[commandNumber];
        }

        public string[] cmdNames()
        {
            List<string> names = new List<string>();
            foreach( var cmd in commands)
            {
                names.Add(cmd.ToString());
            }
            return names.ToArray();
        }
    }
}
