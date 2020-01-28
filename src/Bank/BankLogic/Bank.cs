using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingSystem.BankLogic
{
    public class Bank
    {
        private Dictionary<int, IBankAccount> accounts;
        private int nextNumber;


        public Bank()
        {
            this.accounts = new Dictionary<int, IBankAccount>();
            this.nextNumber = 0; // Could be with Dependency injection
        }

        public virtual int AddNewAccount(AccountType accountType, AccountOrigin origin)
        {
            IBankAccount newBankAccount = CreateAccount(accountType, origin);
            accounts.Add(newBankAccount.AccountNumber, newBankAccount);
            return newBankAccount.AccountNumber;
        }

        private IBankAccount CreateAccount(AccountType type, AccountOrigin origin) =>
            type switch
            {
                AccountType.SavingAccount    => new SavingAccount(nextNumber++, origin),
                AccountType.RegularChecking  => new RegularChecking(nextNumber++, origin),
                AccountType.InterestChecking => new InterestChecking(nextNumber++, origin),
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(type)),
                
            };

        public IBankAccount GetBankAccount(int accountNumber)
        {
            return accounts[accountNumber];
        }

        public void PayInterest()
        {
            foreach (IBankAccount bankAccount in accounts.Values)
            {
                int interestToPay = (int) (bankAccount.Balance * bankAccount.InterestRate);
                if (interestToPay > 0)
                {
                    bankAccount.Deposit(interestToPay);
                }
            }
        }

        public override string ToString()
        {
            var accountNumbers = accounts.Keys;
            StringBuilder bankInformation = new StringBuilder($"The bank has {accountNumbers.Count()} accounts.");

            foreach (int accountNumber in accountNumbers)
            {
                IBankAccount account = accounts[accountNumber];
                bankInformation.Append($"\n\t{account}");
            }

            return bankInformation.ToString();
        }
    }
}