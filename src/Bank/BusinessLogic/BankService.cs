using System;

namespace BankingSystem.BusinessLogic
{
    public class BankService
    {
        private Bank bank;

        public BankService(Bank bank)
        {
            this.bank = bank;
        }

        public int GetBalance(int accountNumber)
        {
            BankAccount bankAccount = bank.GetBankAccount(accountNumber);
            return bankAccount.Balance;
        }

        public int newAccount(string accountOrigin)
        {
            if (accountOrigin.Equals(""))
            {
                return bank.NewAccount();
            }

            if (Enum.TryParse(accountOrigin, true, out AccountOrigin origin))
            {
                return bank.NewAccount(origin);
            }
            
            throw new ArgumentException($"<{accountOrigin}> is not a valid origin.");
        }

        public void Deposit(int accountNumber, int amount)
        {
            BankAccount bankAccount = bank.GetBankAccount(accountNumber);
            bankAccount.Deposit(amount);
        }

        public bool AuthorizeLoan(int accountNumber, int loanAmount)
        {
            BankAccount bankAccount = bank.GetBankAccount(accountNumber);
            // TODO: intermediate checks
            return bankAccount.HasEnoughCollateral(loanAmount);
        }

        public void PayInterest()
        {
            bank.PayInterest();
        }

        public string GetBankInformation()
        {
            return bank.ToString();
        }
    }
}