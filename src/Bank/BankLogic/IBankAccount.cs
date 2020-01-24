using System;

namespace BankingSystem.Bank
{
    public interface IBankAccount : IComparable<IBankAccount>
    {
        int AccountNumber { get; }
        AccountOrigin AccountOrigin { get; }
        int Balance { get; }
        double InterestRate { get; }
        void Deposit(int amount);
        void Withdraw(int amount);
        bool HasEnoughCollateral(int amount);
        bool ChangeAccount(AccountOrigin AccountOrigin);

        static IBankAccount CreateSavingWithDeposit(int accountNumber, int amount, AccountOrigin origin)
        {
            IBankAccount bankAccount = new SavingsAccount(accountNumber, origin);
            bankAccount.Deposit(amount);
            return bankAccount;
        }

        bool IsEmpty()
        {
            return Balance == 0;
        }
    }
}