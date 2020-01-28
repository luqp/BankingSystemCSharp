using System;

namespace BankingSystem.BankLogic
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount(int accountNumber, AccountOrigin accountOrigin)
            : base (accountNumber, accountOrigin, interestRate : 0.01)
        {}

        protected override double CollateralRatio()
        {
            return 1 / 2;
        }

        protected override string GetAccountType()
        {
            return "Saving";
        }
    }
}