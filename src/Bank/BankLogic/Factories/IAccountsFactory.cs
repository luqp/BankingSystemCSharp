using System;

namespace BankingSystem.BankLogic
{
    interface IAccountsFactory
    {
        IBankAccount Create(int accountNumber, AccountOrigin origin);

        static IBankAccount CreateAccount(AccountType type, AccountOrigin origin, int accountNumber) =>
            type switch
            {
                AccountType.SavingAccount => new SavingAccount(accountNumber, origin),
                AccountType.RegularChecking => new RegularChecking(accountNumber, origin),
                AccountType.InterestChecking => new InterestChecking(accountNumber, origin),
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(type)),
            };
    }
}
