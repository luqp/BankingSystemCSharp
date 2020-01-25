using System;

namespace BankingSystem.BankLogic
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
            IBankAccount bankAccount = bank.GetBankAccount(accountNumber);
            return bankAccount.Balance;
        }

        public int NewAccount(string accountType, string accountOrigin)
        { 
            AccountType type = (AccountType)Enum.Parse(typeof(AccountType), accountType, true);
            AccountOrigin origin;

            if (accountOrigin.Equals(""))
            {
                origin = default(AccountOrigin);   
            }
            else
            {
                origin = (AccountOrigin)Enum.Parse(typeof(AccountOrigin), accountOrigin, true);
            }
            
            return NewAccount(type, origin);
        }

        public int NewAccount(AccountType accountType, AccountOrigin accountOrigin)
        {
            return bank.AddNewAccount(accountType, accountOrigin);
        }

        public void Deposit(int accountNumber, int amount)
        {
            IBankAccount bankAccount = bank.GetBankAccount(accountNumber);
            bankAccount.Deposit(amount);
        }

        public bool AuthorizeLoan(int accountNumber, int loanAmount)
        {
            IBankAccount bankAccount = bank.GetBankAccount(accountNumber);
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