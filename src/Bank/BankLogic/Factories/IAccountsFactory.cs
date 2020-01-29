using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem.BankLogic
{
    interface IAccountsFactory
    {
        IBankAccount Create(int accountNumber, AccountOrigin origin);

        static IBankAccount CreateAccount(AccountType type, AccountOrigin origin, int accountNumber)
        {
            IAccountsFactory factory = type switch
            {
                AccountType.SavingAccount => new SavingsFactory(),
                AccountType.RegularChecking => new RegularCheckingFactory(),
                AccountType.InterestChecking => new InterestCheckingFactory(),
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(origin)),
            };
            return factory.Create(accountNumber, origin);
        }
    }
}
