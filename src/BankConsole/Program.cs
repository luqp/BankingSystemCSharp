using System;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankClient bank = new BankClient();
            bank.run();
        }
    }
}
