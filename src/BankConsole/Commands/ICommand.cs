using BankingSystem.BankLogic;

namespace BankConsole.Commands
{
    interface ICommand
    {
        int Execute(BankService bank, int currentAccount);
    }
}
