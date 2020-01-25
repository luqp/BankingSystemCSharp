using BankingSystem.BankLogic;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankService bankService = new BankService(new Bank());
            BankClient bankSystem = new BankClient();
            bankSystem.run(bankService);
        }
    }
}
