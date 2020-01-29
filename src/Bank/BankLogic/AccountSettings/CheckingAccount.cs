using System;

namespace BankingSystem.BankLogic
{
    public abstract class CheckingAccount : BankAccount
    {
        public CheckingAccount(int accountNumber, AccountOrigin accountOrigin, double interestRate)
            : base(accountNumber, accountOrigin, interestRate)
        {
        }

        protected override double CollateralRatio()
        {
            return 2 / 3;
        }
    }
}