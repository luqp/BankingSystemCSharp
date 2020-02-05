using System.Linq;

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

        public string[] GetCommandNames()
        {
            return (from command in commands 
                    select command.ToString()).ToArray();
        }
    }
}
