using System;

namespace BankingSystem.BankLogic
{
    public abstract class BankAccount : IBankAccount
    {
        protected BankAccount(int accountNumber, AccountOrigin accountOrigin, double interestRate)
        {
            Balance = 0;
            AccountNumber = accountNumber;
            AccountOrigin = accountOrigin;
            InterestRate = interestRate;
        }

        public int AccountNumber { get; }
        public AccountOrigin AccountOrigin { get; }
        public int Balance { get; protected set;}
        public double InterestRate { get; }

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The deposit amount must be greater than 0.");
            }

            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0) 
            {
                throw new ArgumentException("The amount to withdraw must be greater than 0.");
            }

            if (amount > Balance) {
                throw new ArithmeticException("Cannot withdraw amounts greater than the actual balance: " + Balance);
            }

            Balance -= amount;
        }

        public bool HasEnoughCollateral(int amount)
        {
            double ratio = CollateralRatio();
            return amount > 0 && Balance >= amount * ratio;
        }

        public override string ToString()
        {
            string type = GetAccountType();
            return $"{type} account {AccountNumber}: balance = {Balance}, origin = {AccountOrigin}";
        }

        protected abstract double CollateralRatio();
        protected abstract string GetAccountType();
    }
}