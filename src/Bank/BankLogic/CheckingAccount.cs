using System;

namespace BankingSystem.BankLogic
{
    public class CheckingAccount : IBankAccount
    {

        public CheckingAccount(int accountNumber, AccountOrigin accountOrigin)
        {
            AccountNumber = accountNumber;
            AccountOrigin = accountOrigin;
            Balance = 0;
            InterestRate = 0;
        }

        public int AccountNumber { get; }
        public AccountOrigin AccountOrigin { get; }
        public int Balance { get; private set;}
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
            return Balance >= 2 * amount / 3;
        }

        public bool ChangeAccount(AccountOrigin AccountOrigin)
        {
            return false;
        }

        public int CompareTo(IBankAccount toCompare)
        {
            if (Balance == toCompare.Balance)
                return AccountNumber - toCompare.AccountNumber;
            else
                return Balance - toCompare.Balance;
        }
    }
}