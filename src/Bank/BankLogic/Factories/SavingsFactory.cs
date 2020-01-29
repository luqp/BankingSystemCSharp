namespace BankingSystem.BankLogic
{
    internal class SavingsFactory : IAccountsFactory
    {
        public IBankAccount Create(int accountNumber, AccountOrigin origin)
        {
            return new SavingAccount(accountNumber, origin);
        }
    }
}