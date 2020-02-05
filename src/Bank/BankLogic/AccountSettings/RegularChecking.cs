namespace BankingSystem.BankLogic
{
    internal class RegularChecking : CheckingAccount
    {
        public RegularChecking(int accountNumber, AccountOrigin accountOrigin)
            : base(accountNumber, accountOrigin, interestRate: 0.00)
        {
        }

        protected override string GetAccountType()
        {
            return "Regular Checking";
        }
    }
}