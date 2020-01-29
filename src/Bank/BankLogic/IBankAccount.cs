using System;

namespace BankingSystem.BankLogic
{
    public interface IBankAccount
    {
        int AccountNumber { get; }
        IOwnerStrategy OriginOwner { get; }
        int Balance { get; }
        double InterestRate { get; }
        void Deposit(int amount);
        void Withdraw(int amount);
        bool HasEnoughCollateral(int amount);
        int Fee();
    }
}