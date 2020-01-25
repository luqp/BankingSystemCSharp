using BankingSystem.BankLogic;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareBankAccounts.Run();
            
            BankService bankService = new BankService(new Bank());
            BankClient bankSystem = new BankClient();
            bankSystem.run(bankService);

        }
    }
}
