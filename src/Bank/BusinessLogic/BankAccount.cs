using System;

namespace BankingSystem.BusinessLogic
{
    public class BankAccount
    {

        public BankAccount(int accountNumber, AccountOrigin accountOrigin)
        {
            AccountNumber = accountNumber;
            AccountOrigin = accountOrigin;
            Balance = 0;
        }

        public int AccountNumber { get; }
        public AccountOrigin AccountOrigin { get; }
        public int Balance { get; private set;}

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The deposit amount must be greater than 0.");
            }

            Balance += amount;
        }

        public void withdraw(int amount)
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
            return amount > 0 && Balance >= amount / 2;
        }

        public bool ChangeAccount(AccountOrigin AccountOrigin)
        {
            return false;
        }
    }
}