namespace BankingSystem.BankLogic
{
    internal class InterestCheckingFactory : IAccountsFactory
    {
        public IBankAccount Create(int accountNumber, AccountOrigin origin)
        {
            return new InterestChecking(accountNumber, origin);
        }
    }
}