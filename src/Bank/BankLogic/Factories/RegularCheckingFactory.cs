namespace BankingSystem.BankLogic
{
    internal class RegularCheckingFactory : IAccountsFactory
    {
        public IBankAccount Create(int accountNumber, AccountOrigin origin)
        {
            return new RegularChecking(accountNumber, origin);
        }
    }
}