using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingSystem.BusinessLogic
{
    class Bank
    {
        private Dictionary<int, BankAccount> accounts;
        private int nextAccount;


        public Bank()
        {
            this.accounts = new Dictionary<int, BankAccount>();
            this.nextAccount = 0;
            InterestRate = 0.01;
        }

        public double InterestRate { get; }

        public int NewAccount(AccountOrigin origin = AccountOrigin.LOCAL)
        {
            BankAccount newBankAccount = new BankAccount(nextAccount++, origin);
            accounts.Add(newBankAccount.AccountNumber, newBankAccount);
            return newBankAccount.AccountNumber;
        }

        public BankAccount GetBankAccount(int accountNumber)
        {
            return accounts[accountNumber];
        }

        public void PayInterest()
        {
            foreach (BankAccount bankAccount in accounts.Values)
            {
                int interestToPay = (int) (bankAccount.Balance * InterestRate);
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
                BankAccount account = accounts[accountNumber];
                string origin = account.AccountOrigin.ToString();
                bankInformation.Append($"\n\tAccount {accountNumber} : balance = {account.Balance}, origin = {origin}");
            }

            return bankInformation.ToString();
        }
    }
}