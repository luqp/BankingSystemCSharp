﻿using System;

namespace BankingSystem.BankLogic
{
    public interface IBankAccount
    {
        int AccountNumber { get; }
        AccountOrigin AccountOrigin { get; }
        int Balance { get; }
        double InterestRate { get; }
        void Deposit(int amount);
        void Withdraw(int amount);
        bool HasEnoughCollateral(int amount);
    }
}