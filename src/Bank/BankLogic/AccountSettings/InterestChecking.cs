namespace BankingSystem.BankLogic
{
    internal class InterestChecking : CheckingAccount
    {

        public InterestChecking(int accountNumber, AccountOrigin accountOrigin)
            : base(accountNumber, accountOrigin, interestRate: 0.01)
        {
        }

        protected override string GetAccountType()
        {
            return "Interest Checking";
        }
    }
}