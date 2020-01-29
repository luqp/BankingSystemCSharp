using System;

namespace BankingSystem.BankLogic
{
    public abstract class BankAccount : IBankAccount
    {
        protected BankAccount(int accountNumber, AccountOrigin origin, double interestRate)
        {
            Balance = 0;
            AccountNumber = accountNumber;
            OwnerType = SelectOwnerType(origin);
            InterestRate = interestRate;
        }

        private IOwnerStrategy SelectOwnerType(AccountOrigin origin) =>
            origin switch
            {
                AccountOrigin.FOREIGN => new Foreign(),
                AccountOrigin.LOCAL => new Local(),
                AccountOrigin.RURAL => new Rural(),
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(origin)),
            };

        public int AccountNumber { get; }
        public IOwnerStrategy OwnerType { get; }
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

        public int Fee()
        {
            return OwnerType.Fee();
        }

        public override string ToString()
        {
            string type = GetAccountType();
            return $"{type} account {AccountNumber}: balance = {Balance}, origin = {OwnerType}, fee = {Fee()}";
        }

        protected abstract double CollateralRatio();
        protected abstract string GetAccountType();
    }
}